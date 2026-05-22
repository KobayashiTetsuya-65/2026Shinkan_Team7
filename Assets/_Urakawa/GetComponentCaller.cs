using UnityEngine;
using UnityEngine.UI;

public class GetComponentCaller : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private Button _button;
    public void Start()
    {
        _button = GetComponent<Button>();
    }

    public void SceneChange_button()
    {
        _button.interactable = false;
        SoundManager.Instance.PlaySE(SEType.Button);
        ChangeScene.Instance.FadeSceneChange(_sceneName);
    }
}

