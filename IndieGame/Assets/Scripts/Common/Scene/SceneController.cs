using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx.Async;
using System;

namespace MSyun.Common.Scene {

	using Fade;

	public sealed class SceneController {

		private ISceneFade fade;

		private const int MaxSceneCount = 5;

		[SerializeField]
		private List<SceneName.Scene> prevScene = new List<SceneName.Scene>(MaxSceneCount);
		[SerializeField]
		private List<SceneName.Scene> currentScene = new List<SceneName.Scene>(MaxSceneCount);

		public List<SceneName.Scene> PreviewScene {
			get { return this.prevScene; }
		}
		public List<SceneName.Scene> CurrentScene
		{
			get { return this.currentScene; }
		}

		public void LoadScene(SceneName.Scene name, bool add = false) {
			if (!add) {
				this.prevScene.Clear();
				this.prevScene.AddRange(this.currentScene);
			}

			SceneManager.LoadScene((int)name, add ? LoadSceneMode.Additive : LoadSceneMode.Single);

			this.ChangeSceneList(name, add);
		}

		public async void LoadSceneAsync(SceneName.Scene name, Action<string> callback, bool add = false) {
			if (!add) {
				this.prevScene.Clear();
				this.prevScene.AddRange(this.currentScene);
			}

			await SceneManager.LoadSceneAsync((int)name, add ? LoadSceneMode.Additive : LoadSceneMode.Single).
				ConfigureAwait(Progress.Create<float>(x => Debug.Log(x)));

			this.ChangeSceneList(name, add);

			callback("Load Scene Complete : " + name);
		}

		public async void UnloadSceneAsync(SceneName.Scene name, Action<string> callback) {
			await SceneManager.UnloadSceneAsync((int)name).
				ConfigureAwait(Progress.Create<float>(x => Debug.Log(x)));

			this.currentScene.Remove(name);

			callback("Unload Scene Complete : " + name);
		}

		private void ChangeSceneList(SceneName.Scene name, bool add) {
			if (!add) {
				this.currentScene.Clear();
				this.currentScene.Add(name);
			}
			else {
				this.currentScene.Add(name);
			}
		}
	}
}