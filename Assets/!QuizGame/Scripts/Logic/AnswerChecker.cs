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

        private CellDataBundle[] _possibleBundles;
        private List<List<int>> _possibleTargets = new List<List<int>>();

        private int _currentBundleIndex;//Among all bundles
        private int _currentAnswerIndex;//Only among POSSIBLE targets

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

        public void Init(int currentBundleIndex)
        {
            _currentBundleIndex = currentBundleIndex;

            int possibleAnswerIndex = Random.Range(0, _possibleTargets[currentBundleIndex].Count);

            _currentAnswerIndex = _possibleTargets[_currentBundleIndex][possibleAnswerIndex];

            _UIController.SetTarget(_possibleBundles, _currentBundleIndex, _currentAnswerIndex);
        }

        public void CheckAnswer(Cell cell)
        {
            if (cell.CellData.Identifier.Equals(_possibleBundles[_currentBundleIndex].CellData[_currentAnswerIndex].Identifier))
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
        }

        private void CorrectAnswer()
        {
            _possibleTargets[_currentBundleIndex].Remove(_currentAnswerIndex);

            _levelController.NextLevel(false);
        }

        private void WrongAnswer()
        {

        }
    }

}
