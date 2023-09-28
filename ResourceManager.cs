using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using MelonLoader;
using UnityEngine;

namespace TextureLoader
{
    public static class ResourceManager
    {
        private static readonly Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

        public static Texture2D LoadTexture(string prefix, string resourceName, byte[] bytes)
        {
            if (Textures.ContainsKey($"{prefix}.{resourceName}"))
            {
                throw new ArgumentException("Resource already exists", nameof(resourceName));
            }
            
            var texture = new Texture2D(1, 1);
            ImageConversion.LoadImage(texture, bytes);
            texture.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            texture.wrapMode = TextureWrapMode.Clamp;

            Textures.Add($"{prefix}.{resourceName}", texture);

            return texture;
        }

        public static Texture2D GetTexture(string resourceName)
        {
            return Textures.ContainsKey(resourceName) ? Textures[resourceName] : null;
        }
    }
}
