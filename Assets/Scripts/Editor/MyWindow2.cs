using UnityEditor;
using UnityEngine;

namespace Geekbrains
{
	public class MyWindow : EditorWindow
    {
		{
        public int Number;
        public string Name;
        public bool IsPressed;

        public void OnGUI()
        {
            GUILayout.Label("Kастомное окно");
            EditorGUILayout.HelpBox("Warning!!", MessageType.Warning);

            if (GUILayout.Button("не нажимайте на кнопку"))
            {
                IsPressed = true;
            }
            
            if (IsPressed)
            {
                EditorGUILayout.HelpBox("Вы нажали на кнопку", MessageType.Warning);
                EditorGUILayout.TextField("Колличество префабов");
                Number = EditorGUILayout.IntSlider(Number, 1, 10);

            }

        }
    }
}