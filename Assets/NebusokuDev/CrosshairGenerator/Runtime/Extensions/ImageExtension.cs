using UnityEngine;
using UnityEngine.UI;

namespace NebusokuDev.CrosshairGenerator.Runtime.Extensions
{
    public static class ImageExtension
    {
        public static Image SetTexture2D(this Image target, Texture2D texture2D)
        {
            target.SetTexture2D(texture2D, texture2D.width, texture2D.height);

            return target;
        }
        
        public static Image SetTexture2D(this Image target, Texture2D texture2D, float width, float height)
        {
            target.SetTexture2D(texture2D, new Vector2(width, height));

            return target;
        }

        public static Image SetTexture2D(this Image target, Texture2D texture2D, Vector2 sizeDelta)
        {
            target.rectTransform.sizeDelta = sizeDelta;
            var sprite = texture2D.ToSprite();
            target.sprite = sprite;

            return target;
        }
    }
}