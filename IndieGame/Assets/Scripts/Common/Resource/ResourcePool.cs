using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Async;

namespace MSyun.Common.Resource {
	public class ResourcePool {
		private Dictionary<string, Object> resources = new Dictionary<string, Object>();

		private ResourceLoader loader = new ResourceLoader();


		public Object Request(string path) {
			if (resources.ContainsKey(path))
				return resources[path];

			var asset = loader.Load(path);
			if (asset == null) {
				Debug.LogError("Resources Load : " + path);
				return null;
			}

			resources.Add(path, asset);

			return asset;
		}

		public async UniTask<Object> RequestAsync(string path) {
			if (resources.ContainsKey(path))
				return resources[path];

			var asset = await loader.LoadAsync(path);
			if (asset == null) {
				Debug.LogError("Resources LoadAsync : " + path);
				return null;
			}

			resources.Add(path, asset);

			return asset;
		}

		public void Unload(string path) {
			if (!resources.ContainsKey(path))
				return;

			var asset = this.resources[path];
			resources.Remove(path);
			this.loader.Unload(asset);
		}

		public async UniTask UnloadAll() {
			resources.Clear();
			await this.loader.UnloadAll();
		}
	}
}