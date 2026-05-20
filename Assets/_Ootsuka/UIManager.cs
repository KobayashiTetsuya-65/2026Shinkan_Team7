using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject _panel;


    public void Open()
    {
        _panel.SetActive(true);
    }

    public void CloseMenu()
    {
        _panel.SetActive(false);
    }

}