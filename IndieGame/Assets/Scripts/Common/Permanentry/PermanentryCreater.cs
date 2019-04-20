using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Common.Permanentry {
	using UnityEngine.SceneManagement;
	using Scene;

	public class PermanentryCreater : MonoBehaviour {
		private void Awake() {
			if (PermanentryManager.Instance != null)
				return;

			SceneManager.LoadScene((int)SceneName.Scene.PERMANENTRY, LoadSceneMode.Additive);
		}
	}
}