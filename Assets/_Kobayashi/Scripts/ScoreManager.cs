using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public ResultDataBase ResultDatas => _resultDatas;

    [Header("-----éQè∆-----")]
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private Image _backGround;
    [SerializeField] private ResultDataBase _resultDatas;

    public void DisplayResult(DeathType deathType)
    {
        _scorePanel.SetActive(true);
        _backGround.sprite = _resultDatas.GetCardData(deathType).Sprite;
    }
}
