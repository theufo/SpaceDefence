using UnityEngine;

namespace Controllers.CellControllers
{
    public class CellController : MonoBehaviour
    {
        public Vector2Int Coordinates;
        public Vector3 Position => transform.position;

    }
}