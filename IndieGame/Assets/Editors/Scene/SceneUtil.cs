using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;

namespace EditorUtil.Scene {

	/// <summary>
	/// エディター拡張用シーン管理サポート
	/// </summary>
	/// author : SyunMizuno
	public static class SceneUtil {

		#region struct

		public struct PathAndName {
			public string path;
			public string name;
		};

		#endregion struct


		#region method

		#region AnalyzeNamePath

		/// <summary>
		/// プロジェクト内のシーン名とパスを解析
		/// </summary>
		/// <returns>シーンの名前とパス</returns>
		public static List<PathAndName> AnalyzeNamePathAll() {
			List<PathAndName> listPN = new List<PathAndName>();
			foreach (string scene in AssetDatabase.FindAssets("t:Scene")) {
				PathAndName PN = new PathAndName();
				PN.path = AssetDatabase.GUIDToAssetPath(scene);
				PN.name = System.IO.Path.GetFileNameWithoutExtension(PN.path);

				listPN.Add(PN);
			}
			return listPN;
		}

		/// <summary>
		/// ビルド内のシーン名とパスを解析
		/// </summary>
		/// <returns>シーンの名前とパス</returns>
		public static List<PathAndName> AnalyzeNamePathBuild() {
			List<PathAndName> listPN = new List<PathAndName>();
			foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
				PathAndName PN = new PathAndName();
				PN.path = scene.path;
				PN.name = System.IO.Path.GetFileNameWithoutExtension(PN.path);

				listPN.Add(PN);
			}
			return listPN;
		}

		/// <summary>
		/// ビルド内のアクティブなシーン名とパスを解析
		/// </summary>
		/// <returns>シーンの名前とパス</returns>
		public static List<PathAndName> AnalyzeNamePathActiveBuild() {
			List<PathAndName> listPN = new List<PathAndName>();
			foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
				if (!scene.enabled)
					continue;
				PathAndName PN = new PathAndName();
				PN.path = scene.path;
				PN.name = System.IO.Path.GetFileNameWithoutExtension(scene.path);

				listPN.Add(PN);
			}
			return listPN;
		}

		#endregion AnalyzePath

		#region AnalyzeName

		/// <summary>
		/// プロジェクト内のシーン名を解析
		/// </summary>
		public static List<string> AnalyzeNameAll() {
			List<PathAndName> listPN = AnalyzeNamePathAll();
			List<string> listName = new List<string>();
			for (int i = 0; i < listPN.Count; ++i)
				listName.Add(listPN[i].name);

			return listName;
		}

		/// <summary>
		/// ビルド内のシーン名を検索
		/// </summary>
		public static List<string> AnalyzeNameBuild() {
			List<PathAndName> listPN = AnalyzeNamePathBuild();
			List<string> listName = new List<string>();
			for (int i = 0; i < listPN.Count; ++i)
				listName.Add(listPN[i].name);

			return listName;
		}

		/// <summary>
		/// ビルド内のアクティブなシーン名を検索
		/// </summary>
		public static List<string> AnalyzeNameActiveBuild() {
			List<PathAndName> listPN = AnalyzeNamePathActiveBuild();
			List<string> listName = new List<string>();
			for (int i = 0; i < listPN.Count; ++i)
				listName.Add(listPN[i].name);

			return listName;
		}

		#endregion AnalyzeName

		/// <summary>
		/// ビルド内の開始シーンの検索
		/// </summary>
		/// <returns>一番最初のシーン</returns>
		public static PathAndName FirstBuildNamePath() {
			PathAndName pn = new PathAndName();
			foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
				if (!scene.enabled)
					continue;
				pn.path = scene.path;
				pn.name = System.IO.Path.GetFileNameWithoutExtension(pn.path);
				return pn;
			}

			pn.name = "";
			return pn;
		}

		#endregion method
	}

}