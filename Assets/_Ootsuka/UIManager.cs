using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject _panel;


    public void Open()
    {
        SoundManager.Instance.PlaySE(SEType.Button);
        _panel.SetActive(true);
    }

    public void CloseMenu()
    {
        SoundManager.Instance.PlaySE(SEType.Button);
        _panel.SetActive(false);
    }

}