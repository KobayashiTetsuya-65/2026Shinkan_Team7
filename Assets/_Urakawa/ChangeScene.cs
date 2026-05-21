using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    /// <summary>
    /// シーンの名前を読み込む
    /// </summary>
    /// <param name="sceneName">シーンの名前</param>
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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

    public void TestMethod()
    {
        Debug.Log("TestSingleton method called.");
    }

}
