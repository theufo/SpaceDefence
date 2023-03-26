using System;
using Assets.Scripts.Core.WindowSystem;
using Configs;
using DefaultNamespace.Controllers;
using UnityEngine;

namespace DefaultNamespace.Managers
{
    public class HangarManager : Common.Singleton<HangarManager>
    {
        [SerializeField] private ShipModulesManager _shipModulesManager;
        [SerializeField] private ShipSelectionManager _selectionManager;
        
        public HangarState HangarState { get; private set; }

        private ShipView _shipView;

        private void Awake()
        {
            base.Awake();
            
            _selectionManager.Init(ConfigsManager.Instance.GetShipsConfig());
            _shipModulesManager.Init(ConfigsManager.Instance.GetModulesConfig());
        }
        
        public void Init()
        {
            SetState(HangarState.SelectShip);
        }

        public void CompleteSelectShip(ShipView shipView)
        {
            _shipView = shipView;
            SetState(HangarState.EquipShip);
        }

        public void CompleteSetModules()
        {
            SetState(HangarState.BattlePrepare);
        }

        private void SetState(HangarState selectShip)
        {
            switch (selectShip)
            {
                case HangarState.SelectShip:
                    HangarState = HangarState.SelectShip;
                    WindowSystem.ShowScreen<ShipSelectorScreen>();
                    break;
                case HangarState.EquipShip:
                    HangarState = HangarState.EquipShip;
                    _selectionManager.DeInit();
                    _shipModulesManager.InitState();
                    WindowSystem.Hide<ShipSelectorScreen>();
                    WindowSystem.ShowScreen<ModuleSelectorScreen>();
                    _shipView.EnableCamera(true);
                    _shipView.EnableSlots(true, ModuleType.Standard);
                    _shipView.EnableSlots(true, ModuleType.Weapon);
                    break;
                case HangarState.BattlePrepare:
                    _shipView.gameObject.AddComponent<PlayerController>();
                    _shipView.InitForBattleState();
                    WindowSystem.Hide<ModuleSelectorScreen>();
                    GameInitializer.Instance.StartBattle();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(selectShip), selectShip, null);
            }
        }
    }
    
    public enum HangarState
    {
        SelectShip,
        EquipShip,
        BattlePrepare,
    }
}