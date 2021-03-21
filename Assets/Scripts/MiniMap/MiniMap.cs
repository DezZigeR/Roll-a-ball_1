using UnityEngine;

namespace Geekbrains
{
	public sealed class MiniMap : IExecute
	{
		private readonly Transform _player;
		private readonly GameObject _minimap;

		public MiniMap(GameObject minimap)
		{
			_minimap = minimap;
			_player = Camera.main.transform;
			_minimap.transform.parent = null;
			_minimap.transform.rotation = Quaternion.Euler(90.0f, 0, 0);
			_minimap.transform.position = _player.position + new Vector3(0, 5.0f, 0);

			var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

			_minimap.GetComponent<Camera>().targetTexture = rt;
		}

		
		public void Execute(float timeDeltatime)
		{
			var newPosition = _player.position;
			newPosition.y = _minimap.transform.position.y;
			_minimap.transform.position = newPosition;
			_minimap.transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
		}
	}

}