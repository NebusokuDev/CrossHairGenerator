using System;
using NebusokuDev.CrosshairGenerator.Runtime.Extensions;
using UnityEngine;

namespace NebusokuDev.CrosshairGenerator.Runtime
{
    [Serializable]
    public class Crosshair : ICrosshair
    {
        [SerializeField] private Color lineColor = Color.green;
        [Range(0, 150), SerializeField] private int outlineThickness = 1;
        [Range(0f, 1f), SerializeField] private float outlineOpacity = .8f;
        [SerializeField] private bool useCenterDot = true;
        [Range(0, 50), SerializeField] private int dotSize;

        [SerializeField] private bool useInnerLine = true;
        [Range(0f, 1f), SerializeField] private float innerLineOpacity = 1;
        [Range(1, 150), SerializeField] private int innerLineLength = 4;
        [Range(1, 100), SerializeField] private int innerLineThickness = 2;
        [Range(0, 350), SerializeField] private int innerLineGap = 5;

        [SerializeField] private bool useOuterLine = true;
        [Range(0f, 1f), SerializeField] private float outerLineOpacity = 1;
        [Range(1, 150), SerializeField] private int outerLineLength = 3;
        [Range(1, 100), SerializeField] private int outerLineThickness = 2;
        [Range(0, 350), SerializeField] private int outerLineGap = 12;


        public int SizeNeeded()
        {
            var width = innerLineLength + innerLineGap + outerLineLength + outerLineGap + outlineThickness * 2;
            var thickness = innerLineThickness + outerLineThickness;

            var result = width > thickness ? width : thickness;
            return result * 2;
        }


        public Texture2D Generate()
        {
            var texture = new Texture2D(SizeNeeded(), SizeNeeded(), TextureFormat.RGBA32, false)
            {
                name = "Crosshair",
                wrapMode = TextureWrapMode.Clamp,
                filterMode = FilterMode.Point
            };
            var center = SizeNeeded() / 2;

            texture.Erase();

            var outlineColor = Color.Lerp(Color.clear, Color.black, outlineOpacity);

            #region CenterDot

            if (useCenterDot && dotSize > 1)
            {
                texture
                    .DrawCenterDotOutLine(center, dotSize, outlineThickness, outlineColor)
                    .DrawCenterDot(center, dotSize, lineColor);
            }

            #endregion

            #region InnerLines

            if (useInnerLine)
            {
                var innerLineColor = Color.Lerp(Color.clear, lineColor, innerLineOpacity);

                texture
                    .DrawTopOutLine(center, innerLineGap, innerLineThickness, innerLineLength, outlineThickness,
                        outlineColor)
                    .DrawBottomOutLine(center, innerLineGap, innerLineThickness, innerLineLength, outlineThickness,
                        outlineColor)
                    .DrawRightOutLine(center, innerLineGap, innerLineThickness, innerLineLength, outlineThickness,
                        outlineColor)
                    .DrawLeftOutLine(center, innerLineGap, innerLineThickness, innerLineLength, outlineThickness,
                        outlineColor)
                    .DrawRightBox(center, innerLineGap, innerLineThickness, innerLineLength, innerLineColor)
                    .DrawLeftBox(center, innerLineGap, innerLineThickness, innerLineLength, innerLineColor)
                    .DrawTopBox(center, innerLineGap, innerLineThickness, innerLineLength, innerLineColor)
                    .DrawBottomBox(center, innerLineGap, innerLineThickness, innerLineLength, innerLineColor);
            }

            #endregion

            #region OuterLines

            if (useOuterLine)
            {
                var outerLineColor = Color.Lerp(Color.clear, lineColor, outerLineOpacity);

                texture
                    .DrawTopOutLine(center, outerLineGap, outerLineThickness, outerLineLength, outlineThickness,
                        outlineColor)
                    .DrawBottomOutLine(center, outerLineGap, outerLineThickness, outerLineLength, outlineThickness,
                        outlineColor)
                    .DrawRightOutLine(center, outerLineGap, outerLineThickness, outerLineLength, outlineThickness,
                        outlineColor)
                    .DrawLeftOutLine(center, outerLineGap, outerLineThickness, outerLineLength, outlineThickness,
                        outlineColor)
                    .DrawTopBox(center, outerLineGap, outerLineThickness, outerLineLength, outerLineColor)
                    .DrawBottomBox(center, outerLineGap, outerLineThickness, outerLineLength, outerLineColor)
                    .DrawRightBox(center, outerLineGap, outerLineThickness, outerLineLength, outerLineColor)
                    .DrawLeftBox(center, outerLineGap, outerLineThickness, outerLineLength, outerLineColor);
            }

            #endregion

            texture.Apply();

            return texture;
        }
    }
}