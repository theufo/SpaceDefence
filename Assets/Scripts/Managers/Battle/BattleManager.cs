using Assets.Scripts.Core.WindowSystem;
using Controllers;
using Controllers.CellControllers;
using Controllers.CharacterControllers;
using Managers.Init;
using UI.BattleScreen;
using UI.EndGameScreen;
using UnityEngine;
using Utils;

namespace Managers.Battle
{
    public class BattleManager : DefaultNamespace.Common.Singleton<BattleManager>
    {
        [SerializeField] private CellsController _enemyCellsController;
        [SerializeField] private CellsController _playerCellsController;

        private PlayerController _playerController;
        private EnemyController _enemyController;

        private ICharacterController _characterController;
        private bool _battleEnded;

        public void Init()
        {
            _playerController = FindObjectOfType<PlayerController>();
            var playerBattleStatsController = _playerController.gameObject.GetComponent<BattleStatsController>();
            _playerController.Init(_playerCellsController, playerBattleStatsController.WeaponModules);
            _playerController.transform.position = _playerCellsController.GetStartingPosition();

            _enemyController = InitializeEnemyShip();
            var enemyStatsController = _enemyController.gameObject.GetComponent<BattleStatsController>();
            _enemyController.Init(_enemyCellsController, enemyStatsController.WeaponModules);
            _enemyController.transform.position = _enemyCellsController.GetStartingPosition();
            _enemyController.transform.eulerAngles = new Vector3(0, 180, 0); //Face enemy to player

            var screen = WindowSystem.ShowScreen<BattleScreen>();
            screen.SetInfo(playerBattleStatsController, enemyStatsController);
        
            _enemyController.InitBehaviorTree();
        }

        public void EndBattle(ICharacterController loser)
        {
            if (_battleEnded) return;

            ICharacterController winner;
            if (loser is PlayerController)
            {
                winner = _enemyController;
            }
            else
            {
                winner = _playerController;
            }
        
            _battleEnded = true;
        
            _playerController.Disable();
            _enemyController.Disable();
        
            WindowSystem.Hide<BattleScreen>();

            var screen = WindowSystem.ShowScreen<EndGameScreen>();
            screen.SetInfo(winner.CharacterName);
        }

        public void ClearScene()
        {
            Destroy(_playerController.gameObject);
            Destroy(_enemyController.gameObject);
        }

        private EnemyController InitializeEnemyShip()
        {
            var shipConfigs = ConfigsManager.Instance.GetShipsConfig();
            var shipConfig = shipConfigs[Random.Range(0, shipConfigs.Count)];

            var shipInstance = Instantiate(shipConfig.Prefab);
            var shipView = shipInstance.GetComponent<ShipView>();
            shipView.Init(shipConfig);

            var standardSlots = shipView.GetStandardSlots();
            for (int i = 0; i < standardSlots.Length; i++)
            {
                var slot = standardSlots[i];
                var config = ConfigsManager.Instance.GetRandomStandardModule();
                slot.SetModule(FactoryUtils.ProduceModuleView(config));
            }
        
            var weaponSlots = shipView.GetWeaponSlots();
            for (int i = 0; i < weaponSlots.Length; i++)
            {
                var slot = weaponSlots[i];
                var config = ConfigsManager.Instance.GetRandomWeaponModule();
                slot.SetModule(FactoryUtils.ProduceModuleView(config));
            }

            var enemyController = shipInstance.AddComponent<EnemyController>();
            shipView.InitForBattleState();

            return enemyController;
        }
    }
}