using System;
using Configs;
using DefaultNamespace.Controllers.Modules;
using UnityEngine;

public class ModuleView : MonoBehaviour
{
    [SerializeField] private ModuleTrigger _moduleTrigger;

    private bool _isDragging;
    private BoxCollider _collider;

    private Transform _originParent;

    private SlotController _slotController;
    private ModuleConfig _config;
    private Action<ModuleConfig> _callback;

    private IModuleStrategy _moduleStrategy;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _moduleTrigger.OnModuleSlotTouch += OnModuleSlotTouch;
    }

    public void Init(ModuleConfig moduleConfig, Action<ModuleConfig> callback = null)
    {
        _callback = callback;
        _config = moduleConfig;
        _moduleTrigger.Init(_config.Strategy.ModuleType);
    }

    public void SetOrigin(Transform transform)
    {
        _originParent = transform;
        this.transform.parent = _originParent;
    }

    public IModuleStrategy InstantiateStrategy()
    {
        if (_config == null) return null;

        _moduleStrategy = Instantiate(_config.Strategy, transform);
        return _moduleStrategy;
    }

    private void OnModuleSlotTouch(SlotController slotController)
    {
        _slotController = slotController;
    }

    private void OnMouseDown()
    {
        _callback?.Invoke(_config);

        _isDragging = true;
        _collider.enabled = false;
    }

    private void FixedUpdate()
    {
        if (!_isDragging) return;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 40, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var point = hit.point;
            transform.position = point;
        }
    }

    private void OnMouseUp()
    {
        _callback?.Invoke(null);

        _isDragging = false;
        _collider.enabled = true;

        if (_slotController == null)
        {
            transform.parent = _originParent;
            transform.localPosition = Vector3.zero;

            _moduleTrigger.Reset();
        }
        else
        {
            _slotController.SetModule(this);
        }
    }
    
    private void OnMouseOver()
    {
        _callback?.Invoke(_config);
    }

    private void OnMouseExit()
    {
        _callback?.Invoke(null);
    }
}
