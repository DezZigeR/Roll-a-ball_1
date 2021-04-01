using UnityEditor;
using Geekbrains;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ExampleSceneLoaded))]
    public class TestTowEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var t = (ExampleSceneLoaded)target;
            t.T = EditorGUILayout.IntSlider(t.T, 0, 100);
        }
    }
}
