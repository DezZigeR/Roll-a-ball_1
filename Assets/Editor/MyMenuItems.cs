using UnityEditor;

namespace Geekbrains
{
	public class MyMenuItems
    {
		{
        [MenuItem("Window/ Oкно редактора")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindowEditor), false, "Редактор бонусов");
        }

        [MenuItem("Window/ Oкно")]
        private static void MenuOptionAP()
        {
            EditorWindow.GetWindow(typeof(Window), false, "Окно");
        }
    }
}