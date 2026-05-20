using UnityEngine;
public enum StageType
{
    Normal,
    Desert,
    Wetland,
    Wasteland
}

public enum DeathType
{
    OverHeat,
    Stop,
    Explosion,
    Dassen
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public StageType CurrentStageType { get; private set; }
    public bool IsDead { get; private set; } = false;

    [SerializeField] public FuelObjectPool FuelObjectPool;
    [SerializeField] public Canvas Canvas;
    [SerializeField] private FireBox _fireBox;

    [Header("-----êîílê›íË-----")]
    [SerializeField] private float _decreaseFire = -0.2f;

    private bool _isDisplay = false;
    private ScoreManager _scoreManager;
    private DeathType _deathType;

    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 120;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentStageType = StageType.Normal;
        IsDead = false;
        _scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            _fireBox.DecreaseFire(_decreaseFire);
        }
        else
        {
            if (_isDisplay) return;

            _scoreManager.DisplayResult(_deathType);

            _isDisplay = true;
        }

        if(_fireBox.CurrntFire <= 0)
        {
            _deathType = DeathType.Stop;
            IsDead = true;
        }
        else if(_fireBox.CurrntFire >= 100)
        {
            _deathType = DeathType.OverHeat;
            IsDead = true;
        }
    }

    public void StageChange(StageType nextStage)
    {
        CurrentStageType = nextStage;
    }
}
