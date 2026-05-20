using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionDatas/MissionDataBase")]
public class MissionDataBase : ScriptableObject
{
    [SerializeField] private List<MissionData> _resultDatas = new();

    public List<MissionData> ResultDatas { get { return _resultDatas; } }

    private Dictionary<MissionType, MissionData> _dictionaly;

    void Initialize()
    {
        if (_dictionaly == null)
        {
            _dictionaly = new Dictionary<MissionType, MissionData>();
            foreach (var card in _resultDatas)
            {
                if (!_dictionaly.ContainsKey(card.MissionType))
                {
                    _dictionaly.Add(card.MissionType, card);
                }
                else
                {
                    Debug.LogWarning($"重複したキーがあります:{card.MissionType}");
                }
            }
        }
    }

    public MissionData GetCardData(MissionType type)
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
