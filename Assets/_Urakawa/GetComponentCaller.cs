using UnityEngine;

public class GetComponentCaller : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    public void Change_button()
    {
        ChangeScene.Instance.SceneLoad(_sceneName);
    }
}
