using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MSyun.Common.Resource {
	public class ResourceManager : MonoBehaviour {
		public T Load<T>(string path) where T : Object {
			return Resources.Load<T>(path);
		}

		public T LoadAsync<T>(string path) where T : Object {
			T data = null;
			StartCoroutine(this.LoadAsyncEnum<T>(path, data));
			return data;
		}

		public void Unload(Object asset) {
			Resources.UnloadAsset(asset);
		}

		private IEnumerator LoadAsyncEnum<T>(string path, T data) where T : Object {
			var request = Resources.LoadAsync<T>(path);

			while (!request.isDone) {
				Debug.Log("Loading progress:" + request.progress.ToString());
				yield return null;
			}

			data = request.asset as T;
		}
	}
}