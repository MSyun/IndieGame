using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Game.Move {
	public abstract class IMoveModule {
		protected Transform transform;

		public IMoveModule(Transform transform) {
			this.transform = transform;
		}

		public virtual void Release() {
			this.transform = null;
		}
	}
}