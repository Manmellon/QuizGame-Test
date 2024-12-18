using UnityEngine;

namespace QuizGame
{
    [CreateAssetMenu(fileName = "New CellDataBundle", menuName = "QuizGame/CellDataBundle", order = 2)]
    public class CellDataBundle : ScriptableObject
    {
        [SerializeField]
        private CellData[] _cellData;

        public CellData[] CellData => _cellData;
    }
}
