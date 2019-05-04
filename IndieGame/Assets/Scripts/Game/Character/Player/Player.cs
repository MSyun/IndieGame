using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Game.Object {

	using Common.Permanentry;

	public class Player : ICharacter {

		public Player() {
			int playerNum = 0;
			var module  = PermanentryManager.Instance.GameController.CreateModulePlayer(ref playerNum);
			this.playerNumber = playerNum;
		}

	}
}