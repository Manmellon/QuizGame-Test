using UnityEngine;

namespace QuizGame
{
    [CreateAssetMenu(fileName = "New CellData", menuName = "QuizGame/CellData", order = 3)]
    public class CellData : ScriptableObject
    {
        [SerializeField]
        private string _identifier;

        [SerializeField]
        private Sprite _sprite;

        [SerializeField]
        private float orientationAngle;

        public string Identifier => _identifier;

        public Sprite Sprite => _sprite;

        public float OrientationAngle => orientationAngle;
    }
}
