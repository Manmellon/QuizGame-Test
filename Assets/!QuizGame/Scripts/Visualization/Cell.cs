using UnityEngine;
using UnityEngine.UI;

namespace QuizGame
{
    public class Cell : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private Image _image;

        private CellData _cellData;

        public CellData CellData => _cellData;

        public void Init(CellData cellData, System.Action<Cell> ButtonAction, bool bounceEffect)
        {
            _cellData = cellData;

            _image.sprite = _cellData.Sprite;

            _button.onClick.RemoveAllListeners();

            _button.onClick.AddListener(() => ButtonAction(this));
        }
    }

}
