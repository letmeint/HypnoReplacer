using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HypnoReplacer.Helpers
{
    internal static class ImageHelper
    {
        internal static Sprite LoadSprite(string path)
        {
            if (!File.Exists(path))
            {
                Plugin.Logger.LogError($"File not found: {path}");
                return null;
            }

            byte[] fileData = File.ReadAllBytes(path);

            Texture2D tex = new Texture2D(Globals.texture2dWidth, Globals.texture2dHeight);

            if (!tex.LoadImage(fileData))
            {
                Plugin.Logger.LogError("Failed to load image data into texture.");
                return null;
            }

            Sprite newSprite = Sprite.Create(
                tex,
                new Rect(0, 0, tex.width, tex.height),
                new Vector2(0.5f, 0.5f),
                100f
            );
          
            return newSprite;
        }
    }
}
