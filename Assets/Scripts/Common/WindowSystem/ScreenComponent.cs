using UnityEngine;

namespace Assets.Scripts.Core.WindowSystem
{
    public class ScreenComponent : MonoBehaviour, IScreenComponent
    {
        private Screen _screen;

        public virtual void SetInfo(Screen screen)
        {
            _screen = screen;
            
            Register();
        }
        
        private void Register()
        {
            _screen.RegisterComponent(this);
        }

        public virtual void OnShow()
        {
            foreach (Transform child in transform)
            {
                var component = child.gameObject.GetComponent<IScreenComponent>();
                if (component != null)
                {
                    component.OnShow();
                }
            }
        }

        public virtual void OnHide()
        {
            foreach (Transform child in transform)
            {
                var component = child.gameObject.GetComponent<IScreenComponent>();
                if (component != null)
                {
                    component.OnShow();
                }
            }
        }
    }
}