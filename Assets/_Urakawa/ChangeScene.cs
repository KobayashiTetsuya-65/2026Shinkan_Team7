using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float _ChangeTime = 2f;
    //[SerializeField] private string _sceneName;
    public Image _canvasGroup;
    /// <summary>
    /// シーンの名前を読み込む
    /// </summary>
    /// <param name="sceneName">シーンの名前</param>
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void FadeSceneChange(string sceneName)
    {
        FadeOut(sceneName);
        //Invoke("FadeIn", _ChangeTime);
    }
    
    private static ChangeScene instance;
    public static ChangeScene Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject("scene1");
                instance = singletonObject.AddComponent<ChangeScene>();
                DontDestroyOnLoad(singletonObject);
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    public void FadeOut(string sceneName)
    {
        _canvasGroup.color = new Color(0f, 0f, 0f, 0f);
        _canvasGroup.DOFade(1, _ChangeTime).OnComplete(() =>
        {
            ChangeScene.Instance.SceneLoad(sceneName);
            FadeIn();
        });

    }


    public void FadeIn()
    {
        _canvasGroup.color = new Color(0f, 0f, 0f, 1f);
        _canvasGroup.DOFade(0, 2f);
    }

    public void TestMethod()
    {
        Debug.Log("TestSingleton method called.");
    }

}
