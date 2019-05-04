using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Game.Object {

	using Move;
	using Common.Input;

	public abstract class IObject : MonoBehaviour {
		protected IMoveModule moveModule;
		protected IInputModule inputModule;

		public int playerNumber { protected set; get; } = -1;

	}
}