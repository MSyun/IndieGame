using System.Collections;
using System.Collections.Generic;
using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;

namespace MSyun.Common.Fade {
	public sealed class SampleFade : IFade {

		private Image image;

		public void SetImage(Image image) {
			this.image = image;
		}

		protected override void UniqueFadeIn(float seconds) {
			float curTime = 0.0f;
			Color color = image.color;
			while (seconds > curTime) {
				curTime += 0.01f;

				color.a = Mathf.Lerp(0.0f, 1.0f, seconds / curTime);
				image.color = color;
			}
		}

		protected override void UniqueFadeOut(float seconds) {
			float curTime = 0.0f;
			Color color = image.color;
			while (seconds > curTime) {
				curTime += 0.01f;

				color.a = Mathf.Lerp(1.0f, 0.0f, seconds / curTime);
				image.color = color;
			}
		}
	}
}