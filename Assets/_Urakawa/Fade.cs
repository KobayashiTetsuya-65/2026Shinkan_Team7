using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// フェードインフェードアウトする
/// </summary>
public class Fade : MonoBehaviour
{
    [SerializeField,Range(0f,10f)] private float _ChangeTime = 2f;
    [SerializeField] private string _sceneName;
    public Image _canvasGroup;

    public void FadeOut()
    {
        _canvasGroup.color = new Color(0f, 0f, 0f,0f);
        _canvasGroup.DOFade(1, _ChangeTime).OnComplete(() =>
        {
            ChangeScene.Instance.SceneLoad(_sceneName);
        });

    }
    public void SceneChange()
    {
        FadeOut();
        Invoke("FadeIn", _ChangeTime);
    }
      

    public void FadeIn()
    {
        _canvasGroup.color = new Color(0f, 0f, 0f, 1f);
        _canvasGroup.DOFade(0, 2f);
    }

}