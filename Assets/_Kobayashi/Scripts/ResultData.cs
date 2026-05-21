using UnityEngine;

[CreateAssetMenu(fileName = "ResultDatas/ResultData")]
public class ResultData : ScriptableObject
{
    [SerializeField, Header("Ž€–Sƒ^ƒCƒv")]
    public DeathType _deathType;

    [SerializeField, Header("”wŒi‰æ‘œ")]
    private Sprite _sprite;

    public DeathType DeathType => _deathType;
    public Sprite Sprite => _sprite;
}
