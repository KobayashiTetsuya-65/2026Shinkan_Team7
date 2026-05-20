using UnityEngine;

public class TestButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.StageChange(StageType.Desert);
    }
     public void OnClickNomal()
    {
        GameManager.Instance.StageChange(StageType.Normal);
    }
}
