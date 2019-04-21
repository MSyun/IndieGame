using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx.Async;
using System;
using UnityEngine.Events;

namespace MSyun.Common.Scene {

	public sealed class SceneController {

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

		public UnityEvent OnBeginLoadScene { private set; get; } = new UnityEvent();
		public UnityEvent OnEndLoadScene { private set; get; } = new UnityEvent();

		public void LoadScene(SceneName.Scene name, bool add = false, bool fade = true) {
			if (!add) {
				this.prevScene.Clear();
				this.prevScene.AddRange(this.currentScene);
			}

			this.OnBeginLoadScene.Invoke();
			SceneManager.LoadScene((int)name, add ? LoadSceneMode.Additive : LoadSceneMode.Single);
			this.OnEndLoadScene.Invoke();

			this.ChangeSceneList(name, add);
		}

		public async UniTask LoadSceneAsync(
			SceneName.Scene name,
			Action<string> callback,
			bool add = false,
			bool fade = true) {
			if (!add) {
				this.prevScene.Clear();
				this.prevScene.AddRange(this.currentScene);
			}

			this.OnBeginLoadScene.Invoke();
			await SceneManager.LoadSceneAsync((int)name, add ? LoadSceneMode.Additive : LoadSceneMode.Single).
				ConfigureAwait(Progress.Create<float>(x => Debug.Log("Loading late : " + x)));
			this.OnEndLoadScene.Invoke();

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