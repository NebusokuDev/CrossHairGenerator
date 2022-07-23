using UnityEngine;

namespace NebusokuDev.CrosshairGenerator.Runtime.Extensions
{
    public static class CrosshairHelper
    {
        public static Texture2D DrawCenterDotOutLine(this Texture2D texture, int center, int size, int outlineThickness,
            Color color)
        {
            texture.DrawCenterDot(center, size + outlineThickness * 2, color);

            return texture;
        }

        public static Texture2D DrawTopOutLine(this Texture2D texture, int center, int gap, int thickness, int length,
            int outlineThickness, Color color)
        {
            texture.DrawTopBox(center, gap - outlineThickness, thickness + outlineThickness * 2,
                length + outlineThickness * 2, color);

            return texture;
        }

        public static Texture2D DrawBottomOutLine(this Texture2D texture, int center, int gap, int thickness,
            int length,
            int outlineThickness, Color color)
        {
            texture.DrawBottomBox(center, gap - outlineThickness, thickness + outlineThickness * 2,
                length + outlineThickness * 2, color);
            return texture;
        }

        public static Texture2D DrawRightOutLine(this Texture2D texture, int center, int gap, int thickness, int length,
            int outlineThickness, Color color)
        {
            texture.DrawRightBox(center, gap - outlineThickness, thickness + outlineThickness * 2,
                length + outlineThickness * 2, color);
            return texture;
        }

        public static Texture2D DrawLeftOutLine(this Texture2D texture, int center, int gap, int thickness, int length,
            int outlineThickness, Color color)
        {
            texture.DrawLeftBox(center, gap - outlineThickness, thickness + outlineThickness * 2,
                length + outlineThickness * 2, color);
            return texture;
        }

        public static Texture2D DrawCenterDot(this Texture2D texture, int center, int size, Color color)
        {
            texture.DrawBox(center - size / 2, center - size / 2, size, size, color);
            return texture;
        }

        public static Texture2D DrawBottomBox(this Texture2D texture, int center, int gap, int thickness, int length,
            Color color)
        {
            texture.DrawBox(center - thickness / 2, center - length - gap + thickness % 2, thickness, length, color);
            return texture;
        }

        public static Texture2D DrawTopBox(this Texture2D texture, int center, int gap, int thickness, int length,
            Color color)
        {
            texture.DrawBox(center - thickness / 2, center + gap, thickness, length, color);
            return texture;
        }

        public static Texture2D DrawRightBox(this Texture2D texture, int center, int gap, int thickness, int length,
            Color color)
        {
            texture.DrawBox(center + gap, center - thickness / 2, length, thickness, color);
            return texture;
        }

        public static Texture2D DrawLeftBox(this Texture2D texture, int center, int gap, int thickness, int length,
            Color color)
        {
            texture.DrawBox(center - length - gap + thickness % 2, center - thickness / 2, length, thickness, color);
            return texture;
        }
    }
}