using Configs;
using Controllers;
using Controllers.Ship;
using UnityEngine;

public class ShipView : MonoBehaviour
{
    [SerializeField] private ShipSlotsController _shipSlotsController;
    [SerializeField] private GameObject _camera;
    [SerializeField] private MeshCollider _meshCollider;
    [SerializeField] private BoxCollider _battleCollider;

    public BattleStatsController BattleStatsController { get; private set; }

    public ShipConfig ShipConfig => _shipConfig;

    private ShipConfig _shipConfig;
    
    public void HighlightAllSlots(bool highlight)
    {
        _shipSlotsController.HighlightSlots(highlight, ModuleType.Standard);
        _shipSlotsController.HighlightSlots(highlight, ModuleType.Weapon);
    }
    
    public void HighlightSlots(bool highlight, ModuleType type)
    {
        _shipSlotsController.HighlightSlots(highlight, type);
    }

    public void EnableSlots(bool enable, ModuleType type)
    {
        _shipSlotsController.HighlightSlots(enable, type);
        _shipSlotsController.EnableSlots(enable, type);
    }

    public void EnableCamera(bool enable)
    {
        _camera.SetActive(enable);
    }

    public void Init(ShipConfig config)
    {
        _shipConfig = config;
        _battleCollider.enabled = false;
    }

    public void InitForBattleState()
    {
        gameObject.transform.parent = null;
        DontDestroyOnLoad(gameObject);
        HighlightAllSlots(false);
        _meshCollider.enabled = false;
        _battleCollider.enabled = true;

        BattleStatsController = gameObject.AddComponent<BattleStatsController>();
        BattleStatsController.Init(_shipConfig, _shipSlotsController.InitStandardModuleStrategies(), _shipSlotsController.InitWeaponModuleStrategies());
    }

    public SlotController[] GetStandardSlots()
    {
        return _shipSlotsController.GetStandardSlots();
    }
    
    public SlotController[] GetWeaponSlots()
    {
        return _shipSlotsController.GetWeaponSlots();
    }
}
