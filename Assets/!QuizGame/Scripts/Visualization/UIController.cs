using TMPro;
using UnityEngine;

namespace QuizGame
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private AnswerChecker _answerChecker;

        [SerializeField]
        private CellsGrid _cellsGrid;

        [SerializeField]
        private TextMeshProUGUI _targetText;

        public void UpdateGrid(Level level, CellDataBundle cellDataBundle, bool bounceEffect)
        {
            _cellsGrid.Init(level, cellDataBundle, _answerChecker.CheckAnswer, bounceEffect);
        }

        public void SetTarget(CellDataBundle[] possibleBundles, int currentBundleIndex, int currentAnswerIndex)
        {
            _targetText.text = "Find " + possibleBundles[currentBundleIndex].CellData[currentAnswerIndex].Identifier;
        }
    }

}