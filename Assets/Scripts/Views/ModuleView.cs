using System;
using Configs;
using Controllers.Modules;
using Controllers.Ship;
using UnityEngine;

public class ModuleView : MonoBehaviour
{
    [SerializeField] private ModuleTrigger _moduleTrigger;

    private bool _isDragging;
    private BoxCollider _collider;

    private Transform _originParent;
    private IModuleConfig _config;

    private SlotController _slotController;
    private Action<IModuleConfig> _callback;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _moduleTrigger.OnModuleSlotTouch += OnModuleSlotTouch;
    }

    public void Init(IModuleConfig moduleConfig, Action<IModuleConfig> callback = null)
    {
        _callback = callback;
        _config = moduleConfig;
        _moduleTrigger.Init(_config.ModuleType);
    }

    public void SetOrigin(Transform transform)
    {
        _originParent = transform;
        this.transform.parent = _originParent;
    }

    public IModuleConfig GetConfig()
    {
        return _config;
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