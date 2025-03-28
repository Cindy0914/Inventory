using System.Collections.Generic;
using UnityEngine;

namespace InventoryProject.Managers
{
    public class ResourceManager : Singleton<ResourceManager>
    {
        private readonly Dictionary<string, Object> resourceCache = new Dictionary<string, Object>();

        public T Load<T>(string path) where T : Object
        {
            if (resourceCache.TryGetValue(path, out var value))
            {
                return value as T;
            }

            T resource = Resources.Load<T>(path);

            if (resource == null)
            {
                Debug.LogError($"ResourceManager : Not found resource at path: {path}");
                return null;
            }

            resourceCache.Add(path, resource);
            return resource;
        }

        public bool IsLoaded(string path)
        {
            return resourceCache.ContainsKey(path);
        }

        public void Unload(string path)
        {
            if (resourceCache.TryGetValue(path, out var value))
            {
                resourceCache.Remove(path);
                Resources.UnloadAsset(value);
            }
        }

        public void UnloadAll()
        {
            resourceCache.Clear();
            Resources.UnloadUnusedAssets();
        }
    }
}