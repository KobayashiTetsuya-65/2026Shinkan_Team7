using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResultDatas/ResultDataBase")]
public class ResultDataBase : ScriptableObject
{
    [SerializeField] private List<ResultData> _resultDatas = new();

    public List<ResultData> ResultDatas { get { return _resultDatas; } }

    private Dictionary<DeathType, ResultData> _dictionaly;

    void Initialize()
    {
        if (_dictionaly == null)
        {
            _dictionaly = new Dictionary<DeathType,ResultData>();
            foreach (var card in _resultDatas)
            {
                if (!_dictionaly.ContainsKey(card.DeathType))
                {
                    _dictionaly.Add(card.DeathType, card);
                }
                else
                {
                    Debug.LogWarning($"重複したキーがあります:{card.DeathType}");
                }
            }
        }
    }

    public ResultData GetCardData(DeathType type)
    {
        Initialize();
        if (_dictionaly.TryGetValue(type, out var resultData))
        {
            return resultData;
        }
        Debug.LogWarning($"ID{type}のカードが見つかりません");
        return null;
    }
}
