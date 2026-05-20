using UnityEngine;

public class FireMeter : MonoBehaviour
{
    [Header("-----éQè∆-----")]
    [SerializeField] private RectTransform _needle;

    public void ChangeMeter(float value)
    {
        value = Mathf.Clamp(value, 0f, 100f);
        float angle = Mathf.Lerp(0f, -180f, value / 100f);

        _needle.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
