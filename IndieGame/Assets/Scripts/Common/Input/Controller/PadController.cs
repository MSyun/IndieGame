using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Common.Input.Controller {
	public class PadController : IController {
		protected override bool Jump() {
			return true;
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