using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Controllers
{
    public class CellsController : MonoBehaviour
    {
        [SerializeField] private GameObject _cellPrefab;

        private CellController _currentCell;
        private int _maxX, _maxY;
        private Dictionary<Vector2Int, CellController> _cellControllers;

        public void Awake()
        {
            InitCells(3, 2);

            _currentCell = _cellControllers[new Vector2Int(0, 0)];
        }

        public Vector3 GetStartingPosition()
        {
            return _currentCell.Position;
        }

        public bool TryMoveRight(out Vector3 position)
        {
            if (CanMoveRight())
            {
                _currentCell = _cellControllers[new Vector2Int(_currentCell.Coordinates.x + 1, _currentCell.Coordinates.y)];
                position = _currentCell.Position;
                return true;
            }

            position = Vector3.zero;
            return false;
        }
        
        public bool CanMoveRight()
        {
            return _currentCell.Coordinates.x + 1 < _maxX;
        }

        public bool TryMoveLeft(out Vector3 position)
        {
            if (CanMoveLeft())
            {
                _currentCell = _cellControllers[new Vector2Int(_currentCell.Coordinates.x - 1, _currentCell.Coordinates.y)];
                position = _currentCell.Position;
                return true;
            }

            position = Vector3.zero;
            return false;
        }

        public bool CanMoveLeft()
        {
            return _currentCell.Coordinates.x - 1 >= 0;
        }

        public bool TryMoveUp(out Vector3 position)
        {
            if (CanMoveUp())
            {
                _currentCell = _cellControllers[new Vector2Int(_currentCell.Coordinates.x, _currentCell.Coordinates.y + 1)];
                position = _currentCell.Position;
                return true;
            }

            position = Vector3.zero;
            return false;
        }

        public bool CanMoveUp()
        {
            return _currentCell.Coordinates.y + 1 < _maxY;
        }

        public bool TryMoveDown(out Vector3 position)
        {
            if (CanMoveDown())
            {
                _currentCell = _cellControllers[new Vector2Int(_currentCell.Coordinates.x, _currentCell.Coordinates.y - 1)];
                position = _currentCell.Position;
                return true;
            }

            position = Vector3.zero;
            return false;
        }
        
        public bool CanMoveDown()
        {
            return _currentCell.Coordinates.y - 1 >= 0;
        }

        private void InitCells(int x, int y)
        {
            _maxX = x;
            _maxY = y;

            _cellControllers = new Dictionary<Vector2Int, CellController>();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var instance = Instantiate(_cellPrefab, transform);
                    instance.transform.localPosition = new Vector3(i, j);
                    var controller = instance.GetComponent<CellController>();
                    controller.Coordinates = new Vector2Int(i, j);

                    _cellControllers.Add(controller.Coordinates, controller);
                }
            }

            _currentCell = _cellControllers[new Vector2Int(0, 0)];
        }
    }
}