using UnityEngine;
using UnityEngine.UI;

public class WhistleGauge : MonoBehaviour
{
    public bool IsFull { get; private set; } = false;
    public float CurrentSteam => _currentSteam;
    public Image whistleBar;
    [SerializeField] private WhistleRope _rope;

    private float _temperature;
    private GameManager _gameManager;
    private float _currentSteam = 0f;

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    public void AddSteam(float delta,bool isWhistle)
    {
        float multiplier = 1f;
        if(_gameManager == null) _gameManager = GameManager.Instance;
        _temperature = _gameManager.FireBox.CurrntFire;

        if (!isWhistle)
        {
            if (_temperature >= 80)
            {
                multiplier = 1f;
            }
            else if (_temperature >= 60)
            {
                multiplier = 0.5f;
            }
            else
            {
                multiplier = 0f;
            }
        }



        _currentSteam += delta * multiplier;

        _currentSteam = Mathf.Clamp01(_currentSteam);

        whistleBar.fillAmount = _currentSteam;
        if (_currentSteam >= 1)
        {
            IsFull = true;
        }
        else if(_currentSteam <= 0)
        {
            if (IsFull)
            {
                _gameManager.ChangeWhistleState(false);
                SoundManager.Instance.PlayBGM(BGMType.Nomal);
                _rope.FinishWhistle();
            }
            IsFull = false;
        }
    }
}