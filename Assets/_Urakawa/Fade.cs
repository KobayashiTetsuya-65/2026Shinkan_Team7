using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// フェードインフェードアウトする
/// </summary>
public class Fade : MonoBehaviour
{
    public Image _canvasGroup;

    public void FadeOut()
    {
        _canvasGroup.DOFade(1, 2f).OnComplete(Change_button);

    }
    private void Start()
    {
        FadeOut();
    }
    [SerializeField] private string _sceneName;   
    public void Change_button()
    {
         ChangeScene.Instance.SceneLoad(_sceneName);
    }
    
}