using UnityEngine;

namespace QuizGame
{
    [System.Serializable]
    public struct Level
    {
        public Vector2Int gridSize;
        public int cellsCount;
    }

    [CreateAssetMenu(fileName = "New LevelsTemplate", menuName = "QuizGame/LevelsTemplate", order = 1)]
    public class LevelsTemplate : ScriptableObject
    {
        [SerializeField]
        private Level[] _levels;

        public Level[] levels => _levels;
    }

}
