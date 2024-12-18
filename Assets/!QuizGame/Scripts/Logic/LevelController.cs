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
        private LevelsTemplate levelsTemplate;

        [SerializeField]
        private CellDataBundle[] possibleBundles;

        private int _currentLevel;

        private void Start()
        {
            _answerChecker.SetAllTargets(possibleBundles);

            _currentLevel = -1;

            NextLevel(true);
        }


        public void NextLevel(bool bounceEffect)
        {
            _currentLevel++;

            int randBundle = Random.Range(0, possibleBundles.Length);

            _UIController.UpdateGrid(
                levelsTemplate.levels[_currentLevel], possibleBundles[randBundle], bounceEffect);

            _answerChecker.Init(randBundle);
        }
    }

}
