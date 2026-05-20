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

public enum MissionType
{
    Wood,
    Stone,
    Bridge
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public StageType CurrentStageType { get; private set; }
    public bool IsDead { get; private set; } = false;
    public int Score { get; private set; } = 0;

    [SerializeField] private GameObject _player;
    [SerializeField] public FuelObjectPool FuelObjectPool;
    [SerializeField] public Canvas Canvas;
    [SerializeField] private FireBox _fireBox;

    [Header("-----êîílê›íË-----")]
    [SerializeField] private float _decreaseFire = -0.2f;

    private bool _isDisplay = false;
    private ScoreViewManager _scoreManager;
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
        _scoreManager = FindAnyObjectByType<ScoreViewManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            ScoreUpdate();
            _fireBox.DecreaseFire(_decreaseFire);
        }
        else
        {
            if (_isDisplay) return;

            _scoreManager.DisplayResult(_deathType);

            _isDisplay = true;
        }

        if (_fireBox.CurrntFire <= 0)
        {
            _deathType = DeathType.Stop;
            IsDead = true;
        }
        else if (_fireBox.CurrntFire >= 100)
        {
            _deathType = DeathType.OverHeat;
            IsDead = true;
        }
    }
    private void ScoreUpdate()
    {
        Score = (int)_player.transform.position.z;
    }

    public void StageChange(StageType nextStage)
    {
        CurrentStageType = nextStage;
    }
}
