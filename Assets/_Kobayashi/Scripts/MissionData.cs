using UnityEngine;

[CreateAssetMenu(fileName = "MissionDatas/MissionData")]
public class MissionData : ScriptableObject
{
    [SerializeField, Header("ミッションの種類")]
    private MissionType _missionType;

    [SerializeField,Header("説明文")]
    private string _missionName;

    [SerializeField, Header("オブジェクト")]
    private GameObject _prefab;

    [SerializeField, Header("どんぐらい先")]
    private float _fowerdMeter;

    public MissionType MissionType => _missionType;
    public string MissionName => _missionName;
    public GameObject Prefab => _prefab;
    public float FowerdMeter => _fowerdMeter;
}
