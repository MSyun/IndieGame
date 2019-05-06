using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSyun.Common.Input {

	using Game.Input;

	public enum InputType {
		None,
		System,
		Game,
		GameMenu,
	}

	/// <summary>
	/// System : 1つで十分、やるなら引数にプレイヤー番号渡すくらい
	/// Game : キャラクター数分作成
	/// Menu : 1つで十分
	/// </summary>
	public sealed class GameController {

		public const int MaxPlayerCount = 4;
		public const int NotFoundPlayerNumber = -1;

		/// NOTE : 最大8人までの状態
		/// 必要があれば変更
		private byte usePlayerNumber = (byte)0x0000;

		private SystemInputModule systemModule;
		private IInputModule[] gameModules = new IInputModule[MaxPlayerCount];
		private MenuInputModule menuModule;

		public InputType TypeCurrent { private set; get; } = InputType.System;

		public void Initialize() {

		}

		public void Release() {
			for(int i = 0; i < MaxPlayerCount; i++) {
				this.RemovePlayer(i);
			}

			this.DeleteModuleSystem();
			this.DeleteModuleMenu();
		}

		public void SetType(InputType type) {
			this.TypeCurrent = type;
		}

		public SystemInputModule CreateModuleSystem() {
			if (this.systemModule == null)
				this.systemModule = new SystemInputModule();

			return this.systemModule;
		}

		public void DeleteModuleSystem() {
			if (this.systemModule == null)
				return;

			this.systemModule.Delete();
			this.systemModule = null;
		}

		public IInputModule CreateModuleGameMenu() {
			if (this.menuModule == null)
				this.menuModule = new MenuInputModule();

			return this.menuModule;
		}

		public void DeleteModuleMenu() {
			if (this.menuModule == null)
				return;

			this.menuModule.Delete();
			this.menuModule = null;
		}

		public IInputModule CreateModulePlayer(ref int playerNum) {
			playerNum = this.GetEmptyPlayerNumber();
			if (playerNum == NotFoundPlayerNumber) {
				Debug.LogError("GameController.Create : Maximum number of people already");
				return null;
			}

			this.gameModules[playerNum] = new ActionInputModule();

			return this.gameModules[playerNum];
		}

		public void RemovePlayer(int playerNum) {
			bool use = false;
			for (int i = 0; i < MaxPlayerCount; i++) {
				if ((this.usePlayerNumber & (0x0001 << i)) != 0x0001)
					continue;

				use = true;
				this.usePlayerNumber &= (byte)(0x1110 << i);
				return;
			}
		}

		private int GetEmptyPlayerNumber() {
			int playerNum = NotFoundPlayerNumber;
			for (int i = 0; i < MaxPlayerCount; i++) {
				if ((this.usePlayerNumber & (0x0001 << i)) == 0x0001)
					continue;

				playerNum = i;
				this.usePlayerNumber |= (byte)(0x0001 << i);
				break;
			}

			return playerNum;
		}

		public void Update() {
			switch (this.TypeCurrent) {
				case InputType.None:
					break;

				case InputType.System:
					this.systemModule?.Update();
					break;

				case InputType.Game:
					for (int i = 0; i < MaxPlayerCount; i++) {
						this.gameModules[i]?.Update();
					}
					break;

				case InputType.GameMenu:
					this.menuModule?.Update();
					break;

				default:
					break;
			}
		}
	}
}