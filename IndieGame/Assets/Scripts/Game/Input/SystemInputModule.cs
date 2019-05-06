using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Game.Input {

	using Common.Input;

	public sealed class SystemInputModule : IInputModule {

		public override void Update() {
			
		}

		public bool A() {
			if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
				return true;

			return false;
		}

	}
}