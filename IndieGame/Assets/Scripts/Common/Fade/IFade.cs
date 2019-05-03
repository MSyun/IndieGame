using UnityEngine;
using UnityEngine.Events;

namespace MSyun.Common.Fade {
	public abstract class IFade {

		public UnityEvent OnEndFadeOut = new UnityEvent();
		public UnityEvent OnEndFadeIn = new UnityEvent();

		protected bool isPlay = false;
		protected bool isReverse = false;

		/// <summary>
		/// 0.0 ~ 1.0
		/// </summary>
		protected float curSeconds = 0.0f;
		protected float fadeSeconds = 1.0f;

		public virtual void Initialize(bool reverse = false) {
			this.isPlay = false;
			this.isReverse = reverse;

			if (!reverse) {
				this.curSeconds = 0.0f;
			}
			else {
				this.curSeconds = 1.0f;
			}
		}

		public void Update() {
			if (!this.isPlay)
				return;

			if (!isReverse) {
				this.curSeconds += this.AddSeconds();
				this.FadeOut();
				if (curSeconds >= 1.0f) {
					this.OnEndFadeOut.Invoke();
				}
			}
			else {
				this.curSeconds -= this.AddSeconds();
				this.FadeIn();
				if (curSeconds <= 0.0f) {
					this.OnEndFadeIn.Invoke();
				}
			}
		}

		public void Play(
			bool reverse = false,
			float seconds = 1.0f,
			bool initialize = false) {
			if (initialize) {
				this.Initialize(reverse);
			}

			this.isPlay = true;
			this.isReverse = reverse;
			this.fadeSeconds = seconds;
		}

		public void Stop() {
			this.isPlay = false;
		}

		public void Resume() {
			this.isPlay = true;
		}

		protected abstract void FadeOut();

		protected abstract void FadeIn();

		public void AddEndFadeOutEvent(UnityAction func) {
			OnEndFadeOut.AddListener(func);
		}

		public void RemoveEndFadeOutEvent(UnityAction func) {
			OnEndFadeOut.RemoveListener(func);
		}

		public void AddEndFadeInEvent(UnityAction func) {
			OnEndFadeIn.AddListener(func);
		}

		public void RemoveEndFadeInEvent(UnityAction func) {
			OnEndFadeIn.RemoveListener(func);
		}

		private float AddSeconds() {
			return Time.deltaTime / this.fadeSeconds;
		}
	}
}