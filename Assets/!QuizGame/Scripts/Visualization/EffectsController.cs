using DG.Tweening;
using QuizGame;
using UnityEngine;
using UnityEngine.UI;

public class EffectsController : MonoBehaviour
{
    [SerializeField]
    private UIController _UIController;

    [SerializeField]
    private LevelController _levelController;

    [SerializeField]
    private ParticleSystem _starEffect;

    public void CorrectAnswerEffect(Cell cell)
    {
        cell.objectInsideTransform.localScale = Vector3.zero;

        cell.objectInsideTransform.DOScale(1, 1).SetEase(Ease.OutBounce).onComplete = 
            () => 
        { 
            _levelController.NextLevel(false);

            _starEffect.Stop();
            _starEffect.gameObject.SetActive(false);
        };

        _starEffect.transform.position = cell.objectInsideTransform.position;

        _starEffect.gameObject.SetActive(true);

        _starEffect.Play();
    }

    public void WrongAnswerEffect(Cell cell)
    {
        cell.objectInsideTransform.DOShakePosition(1.0f, new Vector3(20, 0, 0)).SetEase(Ease.InBounce);
    }

    public void Fade(Image image, float value, float duration, System.Action EndAction)
    {
        image.DOKill();

        image.DOFade(value, duration).OnComplete(() => { EndAction?.Invoke(); });
    }
}
