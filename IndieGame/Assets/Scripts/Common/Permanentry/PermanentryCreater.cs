using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Common.Permanentry {
	using UnityEngine.SceneManagement;
	using Scene;
	using Input;

	public class PermanentryCreater : MonoBehaviour {

		[SerializeField]
		private InputType initializeInputType = InputType.System;

		private void Awake() {
			if (PermanentryManager.Instance != null)
				return;

			SceneManager.LoadScene((int)SceneName.Scene.PERMANENTRY, LoadSceneMode.Additive);
		}

		private void Start() {
			PermanentryManager.Instance.GameController.SetType(this.initializeInputType);

			Destroy(this.gameObject);
		}
	}
}