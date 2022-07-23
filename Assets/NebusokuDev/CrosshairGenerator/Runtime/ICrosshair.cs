using UnityEngine;

namespace NebusokuDev.CrosshairGenerator.Runtime
{
    public interface ICrosshair
    {
        public int SizeNeeded();
        
        Texture2D Generate();
    }
}