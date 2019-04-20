using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Common.Permanentry {
	using Scene;

	public class PermanentryCreater : MonoBehaviour {
		private void Awake() {
			if (PermanentryManager.Instance != null)
				return;

			SceneController.LoadScene((int)SceneName.Scene.PERMANENTRY, true);
		}
	}
}