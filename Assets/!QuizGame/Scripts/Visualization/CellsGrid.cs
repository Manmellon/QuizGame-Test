using System.Collections.Generic;
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

        private List<Cell> _cells = new List<Cell>();

        public void Init(Level level, CellDataBundle cellDataBundle, System.Action<Cell> ButtonAction, bool bounceEffect)
        {
            InitGrid(level);

            InitCells(cellDataBundle, level.cellsCount, ButtonAction, bounceEffect);
        }

        private void InitGrid(Level level)
        {
            _grid.constraintCount = level.gridSize.x;

            int widthCell = (int)(_gridRect.rect.width / _grid.constraintCount);
            int heightCell = (int)(_gridRect.rect.height / (level.cellsCount / widthCell));

            int resultSize = Mathf.Min(widthCell, heightCell);
            _grid.cellSize = new Vector2(resultSize, resultSize);
        }

        private void InitCells(CellDataBundle cellDataBundle, int cellsCount, System.Action<Cell> ButtonAction, bool bounceEffect)
        {
            //Create variants
            List<CellData> possibleAnswers = new List<CellData>();
            for (int i = 0; i < cellsCount; i++)
            {
                possibleAnswers.Add(cellDataBundle.CellData[i]);
            }

            //Spawn necessary amount of cells
            while (_grid.transform.childCount < cellsCount)
            {
                Cell cell = Instantiate(_cellPrefab, _grid.transform);

                _cells.Add(cell);
            }

            //Enable necessary amount of cells
            for (int i = 0; i < cellsCount; i++)
            {
                _cells[i].gameObject.SetActive(true);

                int randAnswer = Random.Range(0, possibleAnswers.Count);

                _cells[i].Init(possibleAnswers[randAnswer], ButtonAction, bounceEffect);

                possibleAnswers.RemoveAt(randAnswer);
            }

            //Disable extra cells
            for (int i = cellsCount; i < _grid.transform.childCount; i++)
            {
                _cells[i].gameObject.SetActive(false);
            }
        }
    }
}

