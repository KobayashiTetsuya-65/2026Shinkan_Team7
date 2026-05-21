using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class GetComponentCaller : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    public void SceneChange_button()
    {
     ChangeScene.Instance.FadeSceneChange(_sceneName);
    }
}

