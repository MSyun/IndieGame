using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx.Async;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace MSyun.Common.Scene.Fade {
	public abstract class ISceneFade {

		protected UnityEvent onBeginFadeIn = new UnityEvent();
		protected UnityEvent onEndFadeIn = new UnityEvent();
		protected UnityEvent onBeginFadeOut = new UnityEvent();
		protected UnityEvent onEndFadeOut = new UnityEvent();

		public void AddBeginFadeInEvent(UnityAction func) {
			onBeginFadeIn.AddListener(func);
		}

		public void RemoveBeginFadeInEvent(UnityAction func) {
			onBeginFadeIn.RemoveListener(func);
		}

		public void AddEndFadeInEvent(UnityAction func) {
			onEndFadeIn.AddListener(func);
		}

		public void RemoveEndFadeInEvent(UnityAction func) {
			onEndFadeIn.RemoveListener(func);
		}

		public void AddBeginFadeOutEvent(UnityAction func) {
			onBeginFadeOut.AddListener(func);
		}

		public void RemoveBeginFadeOutEvent(UnityAction func) {
			onBeginFadeOut.RemoveListener(func);
		}

		public void AddEndFadeOutEvent(UnityAction func) {
			onEndFadeOut.AddListener(func);
		}

		public void RemoveEndFadeOutEvent(UnityAction func) {
			onEndFadeOut.RemoveListener(func);
		}

		public void FadeIn(float seconds = 1.0f) {
			this.onBeginFadeIn.Invoke();
			this.onBeginFadeIn.RemoveAllListeners();

			this.UniqueFadeIn(seconds);

			this.onEndFadeIn.Invoke();
			this.onEndFadeIn.RemoveAllListeners();
		}

		public void FadeOut(float seconds = 1.0f) {
			this.onBeginFadeOut.Invoke();
			this.onBeginFadeOut.RemoveAllListeners();

			this.UniqueFadeOut(seconds);

			this.onEndFadeOut.Invoke();
			this.onEndFadeOut.RemoveAllListeners();
		}

		public void Update() {

		}

		protected abstract void UniqueFadeIn(float seconds);
		protected abstract void UniqueFadeOut(float seconds);
	}
}