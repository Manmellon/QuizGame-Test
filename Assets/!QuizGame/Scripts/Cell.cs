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

        private void Start()
        {

        }

        public void Init(CellData cellData, System.Action<CellData> Action)
        {
            _image.sprite = cellData.Sprite;

            _button.onClick.RemoveAllListeners();

            _button.onClick.AddListener(() => Action(cellData));
        }
    }

}
