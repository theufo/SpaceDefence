using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.WindowSystem
{
	public static class WindowSystem
	{
		private static Dictionary<string, GameObject> _screens = new Dictionary<string, GameObject>();

		private static WindowSystemController _windowSystemController;

		public static void Init(WindowSystemController controller)
		{
			_windowSystemController = controller;
		}

		public static T ShowScreen<T>() where T : IScreen
		{
			GameObject screen;

			if (!_screens.TryGetValue(typeof(T).Name, out screen))
			{
				screen = _windowSystemController.CreateWindow<T>();

				_screens.Add(typeof(T).Name, screen);
			}
			else
			{
				if (screen == null)
					throw new Exception($"[WindowSystem] Screen is null");

				screen.transform.SetParent(null);
			}

			screen.SetActive(true);
            screen.GetComponent<IScreen>().OnShow();

			return screen.GetComponent<T>();
		}

		public static void HideCurrent(GameObject screen)
		{
			HideScreen(screen);
		}

		public static bool HasOpened<T>()
		{
			return (_screens.ContainsKey(typeof(T).Name) && _screens[typeof(T).Name].GetComponent<IScreen>().ScreenState == ScreenState.Shown);
		}
		
		public static void HideCurrent(this IScreen screen)
		{
            screen.OnHide();
            (screen as MonoBehaviour).gameObject.SetActive(false);
		}

		public static void ClearPool()
		{
			_screens.Clear();
		}

        public static void Hide<T>()
        {
            if (_screens.TryGetValue(typeof(T).Name, out var targetScreen))
            {
				HideCurrent(targetScreen);
            }
		}

        private static void HideScreen(GameObject screen)
        {
	        if (screen == null)
		        throw new Exception($"[WindowSystem] Screen is null");
	        
	        screen.GetComponent<IScreen>().OnHide();
	        screen.SetActive(false);

	        screen.transform.SetParent(_windowSystemController.Pool);
        }

        public static T GetOpened<T>()
        {
	        if (!_screens.ContainsKey(typeof(T).Name)) throw new Exception($"[WindowSystem] No opened screen of such type");
	        
	        return _screens[typeof(T).Name].GetComponent<T>();
        }
	}
}
