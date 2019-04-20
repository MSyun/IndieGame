using System.Collections.Generic;


namespace MSyun.Common.Scene {

	/// <summary>
	/// シーン名を定数で管理するクラス
	/// </summary>
	public static class SceneName {

		#region enum

		/// <summary>
		/// アクティブなシーン
		/// </summary>
		[System.Serializable]
		public enum Scene : int {
			NONE = -1,
			TITLE,
			PERMANENTRY,
		}

		#endregion enum

		#region variable

		public const string SCENE_TITLE = "Title";
		public const string SCENE_PERMANENTRY = "Permanentry";

		public static Dictionary<Scene, string> NameDic = new Dictionary<Scene, string> {
			{Scene.NONE, ""},
			{Scene.TITLE, SCENE_TITLE},
			{Scene.PERMANENTRY, SCENE_PERMANENTRY},
		};

		#endregion variable
	}
}
