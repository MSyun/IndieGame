using System.Collections.Generic;


namespace Archive {

	/// <summary>
	/// シーン名を定数で管理するクラス
	/// </summary>
	public static class SCENE {

		#region enum

		/// <summary>
		/// アクティブなシーン
		/// </summary>
		[System.Serializable]
		public enum Scene {
			NONE,
			TITLE,
		}

		#endregion enum

		#region variable

		public const string SCENE_TITLE = "Title";

		public static Dictionary<Scene, string> SceneName = new Dictionary<Scene, string> {
			{Scene.NONE, ""},
			{Scene.TITLE, SCENE_TITLE},
		};

		#endregion variable
	}
}
