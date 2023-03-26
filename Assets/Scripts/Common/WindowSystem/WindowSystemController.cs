using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Core.WindowSystem
{
	public class WindowSystemController : MonoBehaviour
	{
		public GameObject[] Screens;

		public Transform Pool;

		private void Awake()
		{
			WindowSystem.Init(this);
			DontDestroyOnLoad(this.gameObject);
		}

		public GameObject CreateWindow<T>() where T : IScreen
		{
			var first = Screens.FirstOrDefault(x => x.GetComponent<IScreen>().GetType() == typeof(T));

			if (first == null)
			{
				throw new Exception($"No screen of type {typeof(T)}");
			}

			return Instantiate(first);
		}

		private void OnDestroy()
		{
			WindowSystem.ClearPool();
		}
	}
}
