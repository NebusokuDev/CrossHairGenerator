using NebusokuDev.CrosshairGenerator.Runtime.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace NebusokuDev.CrosshairGenerator.Runtime
{
    [RequireComponent(typeof(Image))]
    public class CrosshairGenerator : MonoBehaviour
    {
        [SerializeReference, Tooltip("Contains properties that Specify how the crosshair looks.")]
        private ICrosshair crosshair = new Crosshair();

        [Tooltip(
            "Specifies the image to draw the crosshair to. If you leave this empty, this script generates a Canvas and an Image with the correct settings for you.")]
        private Image _image;

        private void Awake()
        {
            InitialiseCrosshairImage();
            GenerateCrosshair();
        }

        private void OnValidate()
        {
            InitialiseCrosshairImage();
            GenerateCrosshair();
        }

        private void InitialiseCrosshairImage()
        {
            if (_image != null) return;

            _image = GetComponent<Image>();
            _image.rectTransform.localPosition = new Vector2(0, 0);
            _image.raycastTarget = false;
        }

        private void GenerateCrosshair() => _image.SetTexture2D(crosshair.Generate(), crosshair.SizeNeeded(), crosshair.SizeNeeded());

        public ICrosshair Crosshair
        {
            get => crosshair;
            set => crosshair = value;
        }
    }
}