using UnityEngine;

public class TestButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.StageChange(StageType.Desert);
    }
}
