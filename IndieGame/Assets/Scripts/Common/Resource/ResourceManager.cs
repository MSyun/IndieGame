using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Async;

namespace MSyun.Common.Resource {
	public sealed class ResourceManager {
		private ResourcePool pool = new ResourcePool();

		public T Load<T>(string path) where T : Object {
			var asset = this.pool.Request(path);

			if (asset == null)
				return null;

			return asset as T;
		}

		public async UniTask<T> LoadAsync<T>(string path) where T : Object {
			var asset = await this.pool.RequestAsync(path);

			if (asset == null)
				return null;

			return asset as T;
		}

		public void Unload(string path) {
			this.pool.Unload(path);
		}

		public async UniTask UnloadAll() {
			await this.pool.UnloadAll();
		}
	}
}