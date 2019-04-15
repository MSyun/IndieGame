using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Async;

namespace MSyun.Common.Resource {
	public sealed class ResourceLoader {

		public Object Load(string path) {
			return Resources.Load<Object>(path);
		}

		public async UniTask<Object> LoadAsync(string path) {
			return await Resources.LoadAsync<Object>(path);
		}

		public void Unload(Object asset) {
			Resources.UnloadAsset(asset);
		}

		public async UniTask UnloadAll() {
			await Resources.UnloadUnusedAssets();
		}
	}
}