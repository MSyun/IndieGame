using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace MSyun.Common.Fade {

	[Serializable]
	public sealed class FadeManager {

		private Dictionary<FadeType, IFade> allFades = new Dictionary<FadeType, IFade>();
		private List<IFade> playFades = new List<IFade>();

		private UnityEvent onBeginFadeIn = new UnityEvent();
		private UnityEvent onEndFadeIn = new UnityEvent();
		private UnityEvent onBeginFadeOut = new UnityEvent();
		private UnityEvent onEndFadeOut = new UnityEvent();

		public FadeFactory factory;

		public void Update() {
			foreach (var fade in playFades) {
				fade.Update();
			}
		}

		public void FadeIn(
			FadeType type,
			float seconds = 1.0f,
			bool initialize = false) {
			this.onBeginFadeIn.Invoke();
			this.onBeginFadeIn.RemoveAllListeners();

			if (!allFades.ContainsKey(type)) {
				allFades.Add(type, this.factory.Create(type));
			}
			var fade = this.allFades[type];
			fade.Play(true, seconds, initialize);
			this.playFades.Add(fade);

			fade.OnEndFadeIn.AddListener(() => {
				this.playFades.Remove(fade);
				this.onEndFadeIn.Invoke();
				this.onEndFadeIn.RemoveAllListeners();
				fade.OnEndFadeIn.RemoveAllListeners();
			});
		}

		public void FadeOut(
			FadeType type,
			float seconds = 1.0f,
			bool initialize = false) {
			this.onBeginFadeOut.Invoke();
			this.onBeginFadeOut.RemoveAllListeners();

			if (!allFades.ContainsKey(type)) {
				allFades.Add(type, this.factory.Create(type));
			}
			var fade = this.allFades[type];
			fade.Play(false, seconds, initialize);
			this.playFades.Add(fade);

			fade.OnEndFadeOut.AddListener(() => {
				this.playFades.Remove(fade);
				this.onEndFadeOut.Invoke();
				this.onEndFadeOut.RemoveAllListeners();
				fade.OnEndFadeOut.RemoveAllListeners();
			});
		}

		public void AllStop() {
			foreach (var fade in playFades) {
				fade.Stop();
			}
		}

		public void AllResume() {
			foreach (var fade in playFades) {
				fade.Resume();
			}
		}

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
	}
}