using System.Collections.Generic;
using UnityEngine;

namespace QuizGame
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField]
        private UIController _UIController;

        [SerializeField]
        private AnswerChecker _answerChecker;

        [SerializeField]
        private EffectsController _effectsController;

        [SerializeField]
        private LevelsTemplate levelsTemplate;

        [SerializeField]
        private CellDataBundle[] possibleBundles;

        private int _currentLevel;

        private void Start()
        {
            _answerChecker.SetAllTargets(possibleBundles);

            Restart();
        }


        public void NextLevel(bool bounceEffect)
        {
            _currentLevel++;

            if (_currentLevel >= levelsTemplate.levels.Length)
            {
                _UIController.EndGame();
                return;
            }

            int randBundle = Random.Range(0, possibleBundles.Length);

            int currentAnswerIndex = _answerChecker.Init(randBundle);

            _UIController.UpdateGrid(
                levelsTemplate.levels[_currentLevel],
                possibleBundles[randBundle],
                currentAnswerIndex,
                bounceEffect);
        }

        public void Restart()
        {
            _currentLevel = -1;

            _UIController.StartGame();
        }
    }

}
