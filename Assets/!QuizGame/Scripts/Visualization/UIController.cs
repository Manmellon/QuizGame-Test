using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuizGame
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private LevelController _levelController;

        [SerializeField]
        private AnswerChecker _answerChecker;

        [SerializeField]
        private EffectsController _effectsController;

        [SerializeField]
        private CellsGrid _cellsGrid;

        [SerializeField]
        private TextMeshProUGUI _targetText;

        [SerializeField]
        private Image _endScreen;

        [SerializeField]
        private Button _restartButton;

        private void Start()
        {
            _restartButton.onClick.AddListener(() =>
            {
                _restartButton.gameObject.SetActive(false);
                _effectsController.Fade(_endScreen, 1f, 1.0f, _levelController.Restart);
            });
        }

        public void UpdateGrid(Level level, CellDataBundle cellDataBundle, int currentAnswerIndex, bool bounceEffect)
        {
            _cellsGrid.Init(level, cellDataBundle, currentAnswerIndex, _answerChecker.CheckAnswer, bounceEffect);
        }

        public void SetTarget(CellDataBundle[] possibleBundles, int currentBundleIndex, int currentAnswerIndex)
        {
            _targetText.text = "Find " + possibleBundles[currentBundleIndex].CellData[currentAnswerIndex].Identifier;
        }

        public void EndGame()
        {
            _endScreen.gameObject.SetActive(true);

            _restartButton.gameObject.SetActive(true);

            _effectsController.Fade(_endScreen, 0.5f, 1.0f, null);
        }

        public void StartGame()
        {
            _cellsGrid.HideAll();

            Color color = _targetText.color;
            color.a = 0.0f;
            _targetText.color = color;

            _effectsController.Fade(_endScreen, 0.0f, 1.0f, 
                () => 
            {
                _endScreen.gameObject.SetActive(false);

                _levelController.NextLevel(true);

                _targetText.DOFade(1.0f, 1.0f);
            });
        }
    }

}