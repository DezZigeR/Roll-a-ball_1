using UnityEditor;
using UnityEngine;

namespace Geekbrains
{
	public class MyWindow : EditorWindow
	{
        [SerializeField] private static GameObject _goodBonus;
        [SerializeField] private static GameObject _badBonus;

        private string _goodBonusName = "GoodBonus";
        private string _badBonusName = "BadBonus";

        private readonly string[] _toolbarStrings = { "Good Bonus", "Bad Bonus" };

        private int _selectedBonus;

        
        private void OnGUI()
        {
            GUILayout.Label("Расстановка бонусов", EditorStyles.boldLabel);

            _goodBonus = EditorGUILayout.ObjectField("Good Bonus", _goodBonus,
                typeof(GameObject), true) as GameObject;

            _badBonus = EditorGUILayout.ObjectField("Bad Bonus", _badBonus,
                typeof(GameObject), true) as GameObject;

            

            _goodBonusName = EditorGUILayout.TextField("Имя Good Bonus'а", _goodBonusName);
            _badBonusName = EditorGUILayout.TextField("Имя Bad Bonus'а", _badBonusName);

            GUILayout.Label("Текущий бонус", EditorStyles.boldLabel);

            _selectedBonus = GUILayout.Toolbar(_selectedBonus, _toolbarStrings);

            if (Event.current.button == 0 && Event.current.type == EventType.MouseDown)
            {
                if (_selectedBonus == 0)
                {
                    Debug.Log("Ставим гуд бонус");
                }

                if (_selectedBonus == 0)
                {
                    Debug.Log("Ставим бэд бонус");
                }
            }
        }
    }
}