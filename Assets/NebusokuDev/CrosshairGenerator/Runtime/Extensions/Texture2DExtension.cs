using UnityEngine;

namespace NebusokuDev.CrosshairGenerator.Runtime.Extensions
{
    public static class Texture2DExtension
    {
        public static Texture2D DrawBox(this Texture2D target, int startX, int startY, int width, int height,
            Color color)
        {
            if (startX + width > target.width || startY + height > target.height)
            {
                Debug.LogWarning("Crosshair box is out of range.");
                return target;
            }

            for (var x = startX; x < startX + width; ++x)
            {
                for (var y = startY; y < startY + height; ++y)
                {
                    target.SetPixel(x, y, color);
                }
            }

            return target;
        }

        public static Texture2D DrawBox(this Texture2D texture2D, Vector2Int position, Vector2Int size, Color color)
        {
            return texture2D.DrawBox(position.x, position.y, size.x, size.y, color);
        }

        public static Texture2D Erase(this Texture2D target) => target.FillColor(Color.clear);

        public static Texture2D FillColor(this Texture2D target, Color color) =>
            target.DrawBox(0, 0, target.width, target.height, color);

        public static Sprite ToSprite(this Texture2D target, Rect rect, Vector2 pivot) =>
            Sprite.Create(target, rect, pivot);


        public static Sprite ToSprite(this Texture2D target) =>
            target.ToSprite(new Rect(0, 0, target.width, target.height), Vector2.one * .5f);
    }
}