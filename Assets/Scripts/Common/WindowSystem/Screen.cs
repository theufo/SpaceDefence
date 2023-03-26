using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.WindowSystem
{
    public abstract class Screen : MonoBehaviour, IScreen
    {
        private List<ScreenComponent> _components = new List<ScreenComponent>();

        public ScreenState ScreenState { get; set; }

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public virtual void OnShow()
        {
           ScreenState = ScreenState.Shown;
           
            foreach (var child in _components)
            {
                child.OnShow();
            }
        }

        public virtual void OnHide()
        {
            ScreenState = ScreenState.Hidden;

            foreach (var child in _components)
            {
                child.OnHide();
            }

            _components.Clear();
        }

        public virtual void HideCurrentScreen()
        {
            WindowSystem.HideCurrent(this.gameObject);
        }

        public void RegisterComponent(ScreenComponent screenComponent)
        {
            _components.Add(screenComponent);
        }
    }
}