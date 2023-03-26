using System.Collections;
using DefaultNamespace.Controllers;
using UnityEngine;

namespace DefaultNamespace.Views
{
    public class ShotView : MonoBehaviour
    {
        [SerializeField] private float _visibleDuration;

        private LineRenderer _lineRenderer;
        private bool _activateShot;
        private float _damage;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.enabled = false;
            _lineRenderer.SetPosition(0, Vector3.zero);
        }

        public void Init(float damage)
        {
            _damage = damage;
        }

        public void Activate()
        {
            _activateShot = true;
        }

        private IEnumerator ShowShot()
        {
            _lineRenderer.enabled = true;

            yield return new WaitForSeconds(_visibleDuration);

            _lineRenderer.enabled = false;
        }

        private void FixedUpdate()
        {
            if (!_activateShot) return;

            _activateShot = false;
            
            int layerMask = 1 << 4;
            
            Debug.DrawRay(transform.position, transform.forward * 50, Color.yellow, 2);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward * 50, out hit, layerMask))
            {
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, hit.point);

                hit.transform.gameObject.GetComponent<BattleStatsController>().ReceiveDamage(_damage);
            }
            else
            {
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, transform.forward * 50);
            }

            StartCoroutine(ShowShot());
        }
    }
}