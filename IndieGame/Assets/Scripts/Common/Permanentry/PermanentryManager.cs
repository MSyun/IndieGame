using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Common.Permanentry {

	using Resource;
	using Scene;

	public class PermanentryManager : MonoBehaviour {

		#region singleton
		private static PermanentryManager instance;
		public static PermanentryManager Instance;

		protected bool Create() {
			if (instance != null) {
				Debug.LogError("Already create instance PermanentryManager");
				return false;
			}

			instance = this;
			return true;
		}
		#endregion // singleton

		public ResourceManager ResourceManager;
		public SceneController SceneController;

		private void Awake() {
			if (!this.Create()) {
				DestroyImmediate(this.gameObject);
				return;
			}

			this.ResourceManager = new ResourceManager();
			this.SceneController = new SceneController();
		}

		private void OnDestroy() {
			this.SceneController = null;
			this.ResourceManager = null;
			instance = null;
		}
	}
}