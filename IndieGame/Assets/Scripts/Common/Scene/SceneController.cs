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

		private SceneName.Scene NextScene = SceneName.Scene.NONE;
		[SerializeField]
		private SceneName.Scene currentScene = SceneName.Scene.TITLE;
		[SerializeField]
		private SceneName.Scene prevScene = SceneName.Scene.NONE;
		public SceneName.Scene CurrentScene
		{
			private set { this.currentScene = value; }
			get { return this.currentScene; }
		}
		public SceneName.Scene PreviewScene
		{
			private set { this.prevScene = value; }
			get { return this.prevScene; }
		}

		public void LoadScene(string name, LoadSceneMode mode = LoadSceneMode.Single) {
			SceneManager.LoadScene(name, mode);
		}

		public void LoadScene(int num, LoadSceneMode mode = LoadSceneMode.Single) {
			SceneManager.LoadScene(num, mode);
		}

		public async void LoadSceneAsync(string name, Action callback, LoadSceneMode mode = LoadSceneMode.Single) {
			await SceneManager.LoadSceneAsync(name, mode).
				ConfigureAwait(Progress.Create<float>(x => Debug.Log(x)));

			callback?.Invoke();
		}

		public async void LoadSceneAsync(int num, Action callback, LoadSceneMode mode = LoadSceneMode.Single) {
			await SceneManager.LoadSceneAsync(num, mode).
				ConfigureAwait(Progress.Create<float>(x => Debug.Log(x)));

			callback?.Invoke();
		}

		public async void UnloadSceneAsync(string name, Action callback) {
			await SceneManager.UnloadSceneAsync(name).
				ConfigureAwait(Progress.Create<float>(x => Debug.Log(x)));

			callback?.Invoke();
		}

		public async void UnloadSceneAsync(int num, Action callback) {
			await SceneManager.UnloadSceneAsync(num).
				ConfigureAwait(Progress.Create<float>(x => Debug.Log(x)));

			callback?.Invoke();
		}
	}
}