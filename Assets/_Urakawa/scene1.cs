using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scene1 : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    public void Change_button()
    {
        SceneManager.LoadScene(_sceneName);
    }
    private static scene1 instance;
    public static scene1 Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject("scene1");
                instance = singletonObject.AddComponent<scene1>();
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
