using System.Collections.Generic;
using UnityEngine;

namespace QuizGame
{
    public class AnswerChecker : MonoBehaviour
    {
        [SerializeField]
        private UIController _UIController;

        [SerializeField]
        private LevelController _levelController;

        [SerializeField]
        private EffectsController _effectController;

        private CellDataBundle[] _possibleBundles;
        private List<List<int>> _possibleTargets = new List<List<int>>();

        private int _currentBundleIndex;
        private int _currentAnswerIndex;

        public void SetAllTargets(CellDataBundle[] possibleBundles)
        {
            _possibleBundles = possibleBundles;

            foreach (CellDataBundle bundle in _possibleBundles)
            {
                List<int> bundleTargets = new List<int>();

                for (int i = 0; i < bundle.CellData.Length; i++)
                {
                    bundleTargets.Add(i);
                }

                _possibleTargets.Add(bundleTargets);
            }
        }

        public int Init(int currentBundleIndex)
        {
            _currentBundleIndex = currentBundleIndex;

            int possibleAnswerIndex = Random.Range(0, _possibleTargets[currentBundleIndex].Count);

            _currentAnswerIndex = _possibleTargets[_currentBundleIndex][possibleAnswerIndex];

            _UIController.SetTarget(_possibleBundles, _currentBundleIndex, _currentAnswerIndex);

            return _currentAnswerIndex;
        }

        public void CheckAnswer(Cell cell)
        {
            if (cell.CellData.Identifier.Equals(_possibleBundles[_currentBundleIndex].CellData[_currentAnswerIndex].Identifier))
            {
                CorrectAnswer(cell);
            }
            else
            {
                WrongAnswer(cell);
            }
        }

        private void CorrectAnswer(Cell cell)
        {
            _possibleTargets[_currentBundleIndex].Remove(_currentAnswerIndex);

            _effectController.CorrectAnswerEffect(cell);
        }

        private void WrongAnswer(Cell cell)
        {
            _effectController.WrongAnswerEffect(cell);
        }
    }

}
