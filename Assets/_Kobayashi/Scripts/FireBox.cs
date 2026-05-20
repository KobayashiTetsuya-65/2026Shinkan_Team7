using UnityEngine;

public class FireBox : MonoBehaviour
{
    public float CurrntFire { get; private set; }

    [Header("-----参照-----")]
    [SerializeField] private FireMeter _fireMeter;

    [Header("-----数値設定-----")]
    [SerializeField, Header("初期火力")] private float _startFire = 60;

    [Header("-----火力上昇倍率-----")]
    [SerializeField, Header("平原ステージ")] private float _normalMag = 1.0f;
    [SerializeField, Header("砂漠ステージ")] private float _dezartMag = 1.3f;
    [SerializeField, Header("湿地ステージ")] private float _wetlandMag = 0.8f;
    [SerializeField, Header("荒地ステージ")] private float _wastelandMag = 1.0f;

    [Header("-----自動火力低下倍率-----")]
    [SerializeField, Header("平原ステージ")] private float _normalDecreaseMag = 1.0f;
    [SerializeField, Header("砂漠ステージ")] private float _dezartDecreaseMag = 0.8f;
    [SerializeField, Header("湿地ステージ")] private float _wetlandDecreaseMag = 1.3f;
    [SerializeField, Header("荒地ステージ")] private float _wastelandDecreaseMag = 1.0f;
    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = GameManager.Instance;
        AddFire(_startFire);
    }

    public void DecreaseFire(float delta)
    {
        CurrntFire = Mathf.Clamp(CurrntFire + (delta * DecreaseDeltaMag(_gameManager.CurrentStageType)),
            0, 100);
        _fireMeter.ChangeMeter(CurrntFire);
    }
    public void AddFire(float delta)
    {
        CurrntFire = Mathf.Clamp(CurrntFire + (delta*CurrentDeltaMag(_gameManager.CurrentStageType)),
            0, 110);
        _fireMeter.ChangeMeter(CurrntFire);
    }

    private float CurrentDeltaMag(StageType stage)
    {
        return stage switch
        {
            StageType.Normal => _normalMag,
            StageType.Desert => _dezartMag,
            StageType.Wetland => _wetlandMag,
            StageType.Wasteland => _wastelandMag,
            _ => _normalMag
        };
    }
    private float DecreaseDeltaMag(StageType stage)
    {
        return stage switch
        {
            StageType.Normal => _normalDecreaseMag,
            StageType.Desert => _dezartDecreaseMag,
            StageType.Wetland => _wetlandDecreaseMag,
            StageType.Wasteland => _wastelandDecreaseMag,
            _ => _normalMag
        };
    }

}
