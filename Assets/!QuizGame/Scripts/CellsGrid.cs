using UnityEngine;
using UnityEngine.UI;

namespace QuizGame
{
    public class CellsGrid : MonoBehaviour
    {
        [SerializeField]
        private GridLayoutGroup _grid;

        [SerializeField]
        private RectTransform _gridRect;

        [SerializeField]
        private Cell _cellPrefab;

        [SerializeField]
        private Vector2Int _size;

        private void Start()
        {

        }

        public void Init(Level level)
        {
            //_grid.cellSize
        }
    }
}

