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
            _image.preserveAspect = true;
            _image.transform.rotation = Quaternion.Euler(0, 0, cellData.OrientationAngle);

            _button.onClick.RemoveAllListeners();

            _button.onClick.AddListener(() => ButtonAction(this));
        }
    }

}
