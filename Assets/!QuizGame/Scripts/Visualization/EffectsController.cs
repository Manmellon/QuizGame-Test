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

    public void CorrectAnswerEffect(Cell cell)
    {
        cell.objectInsideTransform.DOShakeScale(1.0f).onComplete = () => { _levelController.NextLevel(false); };
    }

    public void WrongAnswerEffect(Cell cell)
    {
        cell.objectInsideTransform.DOShakePosition(1.0f, new Vector3(20, 0, 0));
    }

    public void StartGameEffect()
    {

    }

    public void EndGameEffect()
    {
        
    }
    public void RestartSceneEffect()
    {

    }

    /*public void FadeIn(Image image, float value, float duration, System.Action EndAction)
    {
        Fade(image, value, duration, EndAction);
    }

    public void FadeOut(Image image, float value, float duration, System.Action EndAction)
    {
        Fade(image, value, duration, EndAction);
    }*/

    public void Fade(Image image, float value, float duration, System.Action EndAction)
    {
        image.DOKill();

        image.DOFade(value, duration).OnComplete(() => { EndAction?.Invoke(); });
    }
}
