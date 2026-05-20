using UnityEngine;

public class FireBox : MonoBehaviour
{
    public float CurrntFire { get; private set; }
    [Header("-----火力上昇倍率-----")]
    [SerializeField, Header("平原ステージ")] private float _normalMag = 1.0f;
    [SerializeField, Header("砂漠ステージ")] private float _dezartMag = 1.3f;
    [SerializeField, Header("湿地ステージ")] private float _wetlandMag = 0.8f;
    [SerializeField, Header("荒地ステージ")] private float _wastelandMag = 1.0f;
    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = GameManager.Instance;
    }

    public void ChangeFire(float delta)
    {
        CurrntFire = Mathf.Clamp(CurrntFire + (delta*CurrentDeltaMag(_gameManager.CurrentStageType)),
            0, 100);
        Debug.Log("現在の火力 = " + CurrntFire);
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
}
