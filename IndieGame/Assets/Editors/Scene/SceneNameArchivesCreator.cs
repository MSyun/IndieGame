using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Text;
using EditorUtil.Scene;


/// <summary>
/// シーン名スクリプト自動生成
/// </summary>
/// author : SyunMizuno
public class SceneNameArchivesCreator {

	#region variable

	private const string _commandDir = "Custom/CreateArchives/Scene";

	// 書き出しのディレクトリ
	private const string _exportDir = "Assets/Scripts/Fixed/SCENE.cs";

	// ファイル名（拡張子あり・なし
	private static readonly string _fileName = System.IO.Path.GetFileName(_exportDir);
	private static readonly string _fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(_exportDir);

	#endregion variable


	#region method

	/// <summary>
	/// 実行時
	/// </summary>
	[MenuItem(_commandDir)]
	public static void OnCreate() {
		CreateScript();

		EditorUtility.DisplayDialog(_fileName, "スクリプトの生成に成功しました", "OK");
	}


	/// <summary>
	/// スクリプトを作成可能か確認
	/// </summary>
	/// <returns>true. 生成可能 : false. 生成不可能</returns>
	[MenuItem(_commandDir, true)]
	private static bool CheckCreate() {
		return
			!EditorApplication.isPlaying &&
			!EditorApplication.isCompiling &&
			!EditorApplication.isPaused;
	}


	/// <summary>
	/// スクリプトを作成
	/// </summary>
	private static void CreateScript() {
		StringBuilder builder = new StringBuilder();

		CreateClass(builder);
		List<string> SceneNames = SceneUtil.AnalyzeNameActiveBuild();
		CreateEnum(builder, SceneNames);
		CreateVariable(builder, SceneNames);

		// フォルダの確認
		string directoryName = System.IO.Path.GetDirectoryName(_exportDir);
		if (!System.IO.Directory.Exists(directoryName)) {
			System.IO.Directory.CreateDirectory(directoryName);
		}

		System.IO.File.WriteAllText(_exportDir, builder.ToString(), Encoding.UTF8);
		AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
	}

	/// <summary>
	/// Classを作成
	/// </summary>
	/// <param name="Builder">格納する文字列</param>
	private static void CreateClass(StringBuilder Builder) {
		Builder.AppendLine("using System.Collections.Generic;\n\n");
		Builder.AppendLine("namespace Archive {\n");
		Builder.AppendLine("\t/// <summary>");
		Builder.AppendLine("\t/// シーン名を定数で管理するクラス");
		Builder.AppendLine("\t/// </summary>");
		Builder.AppendFormat("\tpublic static class {0} ", _fileNameWithoutExtension).Append("{").AppendLine();
	}

	/// <summary>
	/// Enumを作成
	/// </summary>
	/// <param name="Builder">格納する文字列</param>
	/// <param name="SceneNames">シーン名のリスト</param>
	private static void CreateEnum(StringBuilder Builder, List<string> SceneNames) {
		Builder.AppendLine("\n\t\t#region enum\n");
		Builder.AppendLine("\t\t/// <summary>");
		Builder.AppendLine("\t\t/// アクティブなシーン");
		Builder.AppendLine("\t\t/// </summary>");
		Builder.AppendLine("\t\t[System.Serializable]");
		Builder.AppendLine("\t\tpublic enum Scene {");
		Builder.AppendLine("\t\t\tNONE,");
		foreach (string name in SceneNames)
			Builder.Append("\t\t\t").AppendFormat(@"{0},", name.ToUpper()).AppendLine();
		Builder.AppendLine("\t\t}");
		Builder.AppendLine("\n\t\t#endregion enum");
	}

	/// <summary>
	/// メンバ変数の作成
	/// </summary>
	/// <param name="Builder">格納する文字列</param>
	/// <param name="SceneNames">シーン名のリスト</param>
	private static void CreateVariable(StringBuilder Builder, List<string> SceneNames) {
		Builder.AppendLine("\n\t\t#region variable\n");

		// 定義
		foreach (string name in SceneNames)
			Builder.Append("\t\t").AppendFormat(@"public const string SCENE_{0} = ""{1}"";", name.ToUpper(), name).AppendLine();

		// ディクショナリ作成
		Builder.AppendLine("\n\t\tpublic static Dictionary<Scene, string> SceneName = new Dictionary<Scene, string> {");
		Builder.AppendLine("\t\t\t{Scene.NONE, \"\"},");
		foreach (string name in SceneNames)
			Builder.Append("\t\t\t").AppendFormat(@"{{Scene.{0}, SCENE_{0}}},", name.ToUpper()).AppendLine();
		Builder.AppendLine("\t\t};");

		Builder.AppendLine("\n\t\t#endregion variable");

		Builder.AppendLine("\t}");
		Builder.AppendLine("}");
	}

	#endregion method
}