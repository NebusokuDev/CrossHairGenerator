using UnityEditor;

namespace NebusokuDev.CrosshairGenerator.Editor
{
    [CustomEditor(typeof(NebusokuDev.CrosshairGenerator.Runtime.CrosshairGenerator))]
    public class CrosshairEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}