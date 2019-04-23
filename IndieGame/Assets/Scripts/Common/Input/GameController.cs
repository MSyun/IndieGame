using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Common.Input {

	using Controller;

	public class GameController {

		public enum Type {
			Pc,
			Pad,
			Phone
		};

		public const int MaxPlayerCount = 4;
		public const int NotFoundPlayerNumber = -1;

		private IController[] controllers = new IController[MaxPlayerCount];

		public void Initialize() {
			this.Add(Type.Pc);
		}

		public void Release() {
			for(int i = 0; i < this.controllers.Length; i++) {
				if (this.controllers[i] == null)
					continue;

				this.Remove(i);
			}
		}

		public int Add(Type type) {
			int playerNum = this.GetEmptyPlayerNumber();
			if (playerNum == NotFoundPlayerNumber) {
				Debug.LogError("GameController.Create : Maximum number of people already");
				return NotFoundPlayerNumber;
			}

			IController controller = null;
			switch (type) {
				case Type.Pc:
					controller = new PCController();
					break;

				case Type.Pad:
					controller = new PadController();
					break;

				case Type.Phone:
					controller = new PhoneController();
					break;

				default:
					Debug.LogError("GameController.Create : Not found device type");
					return NotFoundPlayerNumber;
			};

			controller.Create();
			this.controllers[playerNum] = controller;

			return playerNum;
		}

		public void Remove(int playerNum) {
			if (this.controllers[playerNum] == null) {
				Debug.LogError("This player number is not connecting(" + playerNum + ")");
				return;
			}

			this.controllers[playerNum].Destroy();
			this.controllers[playerNum] = null;
		}

		private int GetEmptyPlayerNumber() {
			int playerNum = NotFoundPlayerNumber;
			for (int i = 0; i < MaxPlayerCount; i++) {
				if (this.controllers[i] != null)
					continue;

				playerNum = i;
			}

			return playerNum;
		}

		private IController GetController(int playerNum) {
			if (this.controllers[playerNum] == null) {
				Debug.LogError("This player number is not connecting(" + playerNum + ")");
				return null;
			}

			return this.controllers[playerNum];
		}

		public void Update() {
			foreach (var controller in this.controllers) {
				controller.KeyCheck();
			}
		}
	}
}