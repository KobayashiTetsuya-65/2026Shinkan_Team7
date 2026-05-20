using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject panel;

    public void Open()
    {
        panel.SetActive(true);
    }
}