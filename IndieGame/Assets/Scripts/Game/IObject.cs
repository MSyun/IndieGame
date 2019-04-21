using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Game.Object {
	using Move;

	public abstract class IObject : MonoBehaviour {
		protected IMoveModule moveModule;
	}
}