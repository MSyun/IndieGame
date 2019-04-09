using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MSyun.Common.Input.Controller {
	public abstract class IController {
		public UnityEvent OnJumpEvent { private set; get; }
		public UnityEvent OnAttackEvent { private set; get; }
		public UnityEvent OnDashEvent { private set; get; }
		public UnityEvent OnMoveEvent { private set; get; }

		public void Create() {
			this.OnJumpEvent = new UnityEvent();
			this.OnAttackEvent = new UnityEvent();
			this.OnDashEvent = new UnityEvent();
			this.OnMoveEvent = new UnityEvent();
		}

		public void Destroy() {
			this.DestroyEvent(this.OnJumpEvent);
			this.DestroyEvent(this.OnAttackEvent);
			this.DestroyEvent(this.OnDashEvent);
			this.DestroyEvent(this.OnMoveEvent);
		}

		private void DestroyEvent(UnityEvent ev) {
			if (null == ev)
				return;

			ev.RemoveAllListeners();
			ev = null;
		}

		public void RemoveAllListeners() {
			this.OnJumpEvent.RemoveAllListeners();
			this.OnAttackEvent.RemoveAllListeners();
			this.OnDashEvent.RemoveAllListeners();
			this.OnMoveEvent.RemoveAllListeners();
		}

		public void KeyCheck() {
			if (this.Jump())
				this.OnJumpEvent.Invoke();
			if (this.Attack())
				this.OnAttackEvent.Invoke();
			if (this.Dash())
				this.OnDashEvent.Invoke();
			if (this.Move())
				this.OnMoveEvent.Invoke();
		}
		protected abstract bool Jump();
		protected abstract bool Attack();
		protected abstract bool Dash();
		protected abstract bool Move();
	}
}