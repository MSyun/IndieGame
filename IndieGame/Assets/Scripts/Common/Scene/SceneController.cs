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

		[SerializeField]
		private SceneName.Scene prevScene = SceneName.Scene.NONE;
		[SerializeField]
		private SceneName.Scene currentScene = SceneName.Scene.TITLE;
		private SceneName.Scene NextScene = SceneName.Scene.NONE;

		public SceneName.Scene PreviewScene {
			private set { this.prevScene = value; }
			get { return this.prevScene; }
		}
		public SceneName.Scene CurrentScene
		{
			private set { this.currentScene = value; }
			get { return this.currentScene; }
		}

		public static void LoadScene(string name, bool add = false) {
			SceneManager.LoadScene(name, add ? LoadSceneMode.Additive : LoadSceneMode.Single);
		}

		public static void LoadScene(int num, bool add = false) {
			SceneManager.LoadScene(num, add ? LoadSceneMode.Additive : LoadSceneMode.Single);
		}

		public async void LoadSceneAsync(string name, Action<string> callback, bool add = false) {
			await SceneManager.LoadSceneAsync(name, add ? LoadSceneMode.Additive : LoadSceneMode.Single).
				ConfigureAwait(Progress.Create<float>(x => Debug.Log(x)));

			callback("Load Scene Complete : " + name);
		}

		public async void LoadSceneAsync(int num, Action<string> callback, bool add = false) {
			await SceneManager.LoadSceneAsync(num, add ? LoadSceneMode.Additive : LoadSceneMode.Single).
				ConfigureAwait(Progress.Create<float>(x => Debug.Log(x)));

			callback("Load Scene Complete : " + num);
		}

		public async void UnloadSceneAsync(string name, Action<string> callback) {
			await SceneManager.UnloadSceneAsync(name).
				ConfigureAwait(Progress.Create<float>(x => Debug.Log(x)));

			callback("Unload Scene Complete : " + name);
		}

		public async void UnloadSceneAsync(int num, Action<string> callback) {
			await SceneManager.UnloadSceneAsync(num).
				ConfigureAwait(Progress.Create<float>(x => Debug.Log(x)));

			callback("Unload Scene Complete : " + num);
		}
	}
}