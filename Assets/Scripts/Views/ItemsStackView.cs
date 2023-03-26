using System;
using Configs;
using DefaultNamespace.Utils;
using UnityEngine;

namespace DefaultNamespace.Views
{
    public class ItemsStackView : MonoBehaviour
    {
        [SerializeField] private Transform[] _transforms;

        private int _stackSize;

        public void AddToStack(ModuleConfig configModuleConfig, Action<ModuleConfig> onModuleHighlighted)
        {
            if (_transforms.Length <= _stackSize + 1)
            {
                Debug.LogWarning($"Exceed stack size to add more items!");
                return;
            }

            var view = FactoryUtils.ProduceModuleView(configModuleConfig, onModuleHighlighted);
            view.SetOrigin(_transforms[_stackSize]);
            view.gameObject.transform.localPosition = Vector3.zero;
            
            _stackSize++;
        }
    }
}