using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Game.Object {

	using Attack;

	public abstract class ICharacter : IObject {
		protected IAttackModule attackModule;
	}
}