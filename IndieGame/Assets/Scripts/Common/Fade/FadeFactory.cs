using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MSyun.Common.Fade {

	public enum FadeType {
		Sample,
	}

	public class FadeFactory : MonoBehaviour {

		[SerializeField]
		private Image sampleImage;

		public IFade Create(FadeType type) {
			switch (type) {
				case FadeType.Sample:
					SampleFade fade = new SampleFade();
					fade.SetImage(sampleImage);
					break;

			}

			return null;
		}
	}
}