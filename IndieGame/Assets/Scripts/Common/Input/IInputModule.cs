using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Common.Input {
	public abstract class IInputModule {
		public IInputModule() {

		}

		public abstract void Update();

		/// NOTE : デストラクタの代わり
		public void Delete() {

		}
	}
}