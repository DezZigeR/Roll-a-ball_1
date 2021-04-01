﻿using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
	public sealed class RadarObj : IExecute
	{
		private Image _ico;
		private Radar _radar;

		private void Awake()
		{
			_ico = Resources.Load<Image>("MiniMap/RadarObject");
		}

		private void OnValidate()
		{
			_ico = Resources.Load<Image>("MiniMap/RadarObject");
		}

		private void OnDisable()
		{
			_radar.RemoveRadarObject(gameObject);
		}

		
		public void SetRadar(Radar radar)
		{
			_radar = radar;
			_radar.RegisterRadarObject(gameObject, _ico);
		}
	}
}