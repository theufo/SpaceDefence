using UnityEngine;

namespace DefaultNamespace.Controllers
{
    public class CellController : MonoBehaviour
    {
        public Vector2Int Coordinates;
        public Vector3 Position => transform.position;

    }
}