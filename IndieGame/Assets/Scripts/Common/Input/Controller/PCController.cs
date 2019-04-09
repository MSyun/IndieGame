using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Common.Input.Controller {
	public class PCController : IController {
		protected override bool Jump() {
			return UnityEngine.Input.GetKey(KeyCode.Space);
		}

		protected override bool Attack() {
			return true;
		}

		protected override bool Dash() {
			return true;
		}

		protected override bool Move() {
			return true;
		}
	}
}