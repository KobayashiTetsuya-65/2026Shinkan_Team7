using UnityEngine;
using UnityEngine.UI;

public class WhistleGauge : MonoBehaviour
{
    public Image whistleBar;

    public float whistle = 0f;

    public float addspeed = 0.01f;

    public float temperature = 80f;

    void Update()
    {
        AddSteam(addspeed,false);
    }

    public void AddSteam(float delta,bool isWhistle)
    {
        float multiplier = 1f;

        if (!isWhistle)
        {
            if (temperature >= 80)
            {
                multiplier = 1f;
            }
            else if (temperature >= 60)
            {
                multiplier = 0.5f;
            }
            else
            {
                multiplier = 0f;
            }
        }


        whistle += delta * multiplier;

        whistle = Mathf.Clamp01(whistle);

        whistleBar.fillAmount = whistle;
    }
}