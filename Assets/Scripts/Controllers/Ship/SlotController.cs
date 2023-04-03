using Configs;
using UnityEngine;

namespace Controllers.Ship
{
    public class SlotController : MonoBehaviour
    {
        public bool Empty => _moduleView == null;
        public ModuleView ModuleView => _moduleView;
    
        [SerializeField] private ModuleType _moduleType;

        public ModuleType ModuleType => _moduleType;

        private BoxCollider _collider;
        private MeshRenderer _meshRenderer;

        private ModuleView _moduleView;
    
        private void Awake()
        {
            _collider = GetComponent<BoxCollider>();
            _meshRenderer = GetComponent<MeshRenderer>();

            _meshRenderer.enabled = false;
            _collider.enabled = false;
        }

        public void HighlightSlot(bool highlight)
        {
            _meshRenderer.enabled = highlight;
        }

        public void EnableSlot(bool enable)
        {
            _collider.enabled = enable;
        }

        public void SetModule(ModuleView moduleView)
        {
            _moduleView = moduleView;

            if (moduleView != null)
            {
                moduleView.transform.parent = gameObject.transform;
                moduleView.transform.localPosition = Vector3.zero;
            }
        }
    }
}
