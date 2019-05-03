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

		protected override void FadeIn() {
			this.AlphaChange();
		}

		protected override void FadeOut() {
			this.AlphaChange();
		}

		private void AlphaChange() {
			if (this.image == null) {
				return;
			}

			Color color = image.color;
			color.a = Mathf.Lerp(0.0f, 1.0f, this.curSeconds);
			image.color = color;
		}
	}
}