using UnityEditor;
using UnityEngine;

namespace Geekbrains
{
	[CustomEditor(typeof(TestBehaviour))]
	public class TestBehaviourEditor : UnityEditor.Editor
	{
		private bool _isPressButtonOk;
		
		public override void OnInspectorGUI()
		{
			// DrawDefaultInspector();
			TestBehaviour testTarget = (TestBehaviour)target;
			
			testTarget.Count = EditorGUILayout.IntSlider(testTarget.Count, 10, 50);
			testTarget.Offset = EditorGUILayout.IntSlider(testTarget.Offset, 1, 5);
			EditorGUILayout.DropdownButton(GUIContent.none, FocusType.Keyboard);
			
			testTarget.Obj =
				EditorGUILayout.ObjectField("Объект который хотим вставить",
						testTarget.Obj, typeof(GameObject), false)
					as GameObject;
			
			var isPressButton = GUILayout.Button("Создание объектов по кнопке",
				EditorStyles.colorField);
			
			_isPressButtonOk = GUILayout.Toggle(_isPressButtonOk, "Ok");
			
			if (isPressButton)
			{
				testTarget.CreateObj();
				_isPressButtonOk = true;
			}
			
			if (_isPressButtonOk)
			{
				testTarget.Test1 = EditorGUILayout.Slider(testTarget.Test1, 10, 50);
				EditorGUILayout.HelpBox("Вы нажали на кнопку", MessageType.Warning);
			
				var isPressAddButton = GUILayout.Button("Add Component",
					EditorStyles.miniButtonLeft);
				var isPressRemoveButton = GUILayout.Button("Remove Component",
					EditorStyles.miniButtonLeft);
				if (isPressAddButton)
				{
					testTarget.AddComponent();
				}
				if (isPressRemoveButton)
				{
					testTarget.RemoveComponent();
				}
			}
		}
	}

}