using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MSyun.Common.Scene {

	using Fade;

	public class SceneController {

		private ISceneFade fade;

		public SceneName.Scene CurrentScene { private set; get; }
		public SceneName.Scene PreviewScene { private set; get; }

		public void LoadScene(string name, LoadSceneMode mode = LoadSceneMode.Single) {
			SceneManager.LoadScene(name, mode);
		}

		public void LoadScene(int num, LoadSceneMode mode = LoadSceneMode.Single) {
			SceneManager.LoadScene(num, mode);
		}

		public void LoadSceneAsync(string name, LoadSceneMode mode = LoadSceneMode.Single) {
			var operation = SceneManager.LoadSceneAsync(name, mode);
		}

		public void LoadSceneAsync(int num, LoadSceneMode mode = LoadSceneMode.Single) {
			var operation = SceneManager.LoadSceneAsync(num, mode);
		}

		public void UnloadSceneAsync(string name) {
			var operation = SceneManager.UnloadSceneAsync(name);
		}

		public void UnloadSceneAsync(int num) {
			var operation = SceneManager.UnloadSceneAsync(num);
		}
	}
}