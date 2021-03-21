using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
	public sealed class Radar : IExecute
	{
		private readonly Transform _playerPos; // Позиция главного героя
		private readonly float _mapScale = 2;
		private readonly List<RadarObject> _radObjects = new List<RadarObject>();
		private GameObject _radarGameObject;
		private GameController _gameController;


		public Radar(PlayerBase player, GameObject radar, GameController gameController)
		{
			_playerPos = player.transform;
			_radarGameObject = radar;
			_gameController = gameController;
		}

		
		public void RegisterRadarObject(GameObject o, Image i)
		{
			Image image = _gameController.InstantiateImage(_radarGameObject, i);
			
			_radObjects.Add(new RadarObject { Owner = o, Icon = image });
		}

		public void RemoveRadarObject(GameObject o)
		{
			List<RadarObject> newList = new List<RadarObject>();
			foreach (RadarObject t in _radObjects)
			{
				if (t.Owner == o)
				{
					_gameController.DestroyImage(t.Icon);
					//Destroy(t.Icon);
					continue;
				}
				newList.Add(t);
			}
			_radObjects.RemoveRange(0, _radObjects.Count);
			_radObjects.AddRange(newList);
		}

		private void DrawRadarDots() // Синхронизирует значки на миникарте с реальными объектами
		{
			foreach (RadarObject radObject in _radObjects)
			{
				Vector3 radarPos = (radObject.Owner.transform.position -
									_playerPos.position) * _mapScale;
				
				radObject.Icon.transform.position = new Vector3(radarPos.x,
			  radarPos.z, 0) + _radarGameObject.transform.position;


			}
		}

		

		public void Execute(float timeDeltatime)
		{
			if (Time.frameCount % 2 == 0)
			{
				DrawRadarDots();
			}
		}
	}

	public sealed class RadarObject
	{
		public Image Icon;
		public GameObject Owner;
	}
}