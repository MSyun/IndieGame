using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Common.Permanentry {

	using Resource;
	using Scene;
	using Input;
	using Fade;

	public class PermanentryManager : MonoBehaviour {

		#region singleton
		private static PermanentryManager instance;
		public static PermanentryManager Instance { get { return instance; } }

		protected bool Create() {
			if (instance != null) {
				Debug.LogError("Already create instance PermanentryManager");
				return false;
			}

			instance = this;
			return true;
		}
		#endregion // singleton

		[SerializeField]
		private FadeFactory fadeFactory;

		public ResourceManager ResourceManager { private set; get; }
		public SceneController SceneManager { private set; get; }
		public FadeManager FadeManager { private set; get; }
		public GameController GameController { private set; get; }

		private void Awake() {
			if (!this.Create()) {
				DestroyImmediate(this.gameObject);
				return;
			}

			this.ResourceManager = new ResourceManager();
			this.SceneManager = new SceneController();
			this.GameController = new GameController();
			this.FadeManager = new FadeManager();
			this.FadeManager.factory = this.fadeFactory;
			this.GameController.Initialize();
		}

		private void Update() {
			this.GameController.Update();
			this.FadeManager.Update();
		}

		private void OnDestroy() {
			this.GameController.Release();
			this.GameController = null;
			this.SceneManager = null;
			this.ResourceManager = null;
			instance = null;
		}
	}
}