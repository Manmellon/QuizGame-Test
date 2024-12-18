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

        public void Init(Level level, CellDataBundle cellDataBundle, int currentAnswerIndex, System.Action<Cell> ButtonAction, bool bounceEffect)
        {
            InitGrid(level);

            List<CellData> chosenAnswers = CreateAnswers(level.cellsCount, cellDataBundle, currentAnswerIndex);

            InitCells(chosenAnswers, level.cellsCount, ButtonAction, bounceEffect);
        }

        private void InitGrid(Level level)
        {
            _grid.constraintCount = level.gridSize.x;

            int widthCell = (int)(_gridRect.rect.width / level.gridSize.x);
            int heightCell = (int)(_gridRect.rect.height / level.gridSize.y);
            
            int resultSize = Mathf.Min(widthCell, heightCell);
            _grid.cellSize = new Vector2(resultSize, resultSize);
        }

        private List<CellData> CreateAnswers(int cellsCount, CellDataBundle cellDataBundle, int currentAnswerIndex)
        {
            List<CellData> possibleAnswers = new List<CellData>(cellDataBundle.CellData);

            CellData realAnswer = possibleAnswers[currentAnswerIndex];

            possibleAnswers.RemoveAt(currentAnswerIndex);

            List<CellData> chosenAnswers = new List<CellData>();

            for (int i = 0; i < cellsCount; i++)
            {
                if (possibleAnswers.Count == 0) break;

                int randAnswer = Random.Range(0, possibleAnswers.Count);

                chosenAnswers.Add(possibleAnswers[randAnswer]);

                possibleAnswers.RemoveAt(randAnswer);
            }

            chosenAnswers.Insert(Random.Range(0, chosenAnswers.Count), realAnswer);

            return chosenAnswers;
        }

        private void InitCells(List<CellData> chosenAnswers, int cellsCount, System.Action<Cell> ButtonAction, bool bounceEffect)
        {
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

                _cells[i].Init(chosenAnswers[i], ButtonAction, bounceEffect);
            }

            //Disable extra cells
            for (int i = cellsCount; i < _grid.transform.childCount; i++)
            {
                _cells[i].gameObject.SetActive(false);
            }
        }

        public void HideAll()
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                _cells[i].gameObject.SetActive(false);
            }
        }
    }
}

