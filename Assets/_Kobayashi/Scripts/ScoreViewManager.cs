using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewManager : MonoBehaviour
{
    public ResultDataBase ResultDatas => _resultDatas;

    [Header("-----éQè∆-----")]
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private TextMeshProUGUI _scoreResultText;
    [SerializeField] private Image _backGround;
    [SerializeField] private ResultDataBase _resultDatas;
    [Header("-----ÉCÉìÉQÅ[ÉÄ-----")]
    [SerializeField] private TextMeshProUGUI _scoreIngameText;

    public void DisplayResult(DeathType deathType)
    {
        _scorePanel.SetActive(true);
        _backGround.sprite = _resultDatas.GetCardData(deathType).Sprite;
        _scoreResultText.text = $"{GameManager.Instance.Score}m";
    }
    private void IngameView()
    {
        _scoreIngameText.text = $"{GameManager.Instance.Score}m";
    }
    private void Update()
    {
        IngameView();
    }
}
