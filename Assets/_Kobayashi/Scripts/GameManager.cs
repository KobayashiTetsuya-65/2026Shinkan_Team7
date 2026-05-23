using DG.Tweening;
using TMPro;
using UnityEngine;
public enum StageType : int
{
    Normal,
    Desert,
    Snow,
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
    public bool IsWhistle { get; private set; } = false;
    public int Score { get; private set; } = 0;
    public bool IsCount => _isCount;
    public FireBox FireBox => _fireBox;

    [SerializeField] private GameObject _player;
    [SerializeField] public FuelObjectPool FuelObjectPool;
    [SerializeField] public Canvas Canvas;
    [SerializeField] private FireBox _fireBox;
    [SerializeField] private MissionManager _missionManager;
    [SerializeField] private WhistleGauge _whistleGauge;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private Transform _particleParent;
    [SerializeField] private GameObject _particle;
    [SerializeField] private Transform _eventParticleParent;
    [SerializeField] private GameObject _eventParticle;

    [Header("-----数値設定-----")]
    [SerializeField,Header("火力の減少量")] private float _decreaseFire = -0.2f;
    [SerializeField, Header("ステージ切り替え時間")] private float _stageChangeTime = 15f;
    [SerializeField, Header("ミッション時間")] private float _missionTime = 10f;
    [SerializeField, Header("蒸気ゲージの上昇量")] private float _addspeed = 0.01f;
    [SerializeField, Header("蒸気ゲージの減少量")] private float _decreaseSpeed = -0.01f;
    [SerializeField, Header("死亡後演出時間")] private float _deathTime = 2.0f;

    private bool _isDisplay = false,_isMission = false,_isCount = true;
    private ScoreViewManager _scoreManager;
    private DeathType _deathType;
    private float _stageTimer = 0,_missionTimer = 0,_deathTimer = 0;



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
        SoundManager.Instance.PlayBGM(BGMType.Nomal);
        CountDownAnimation();
        _whistleGauge.AddSteam(0,false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            if (_isCount) return;


            _stageTimer += Time.deltaTime;

            if(!_isMission)
                _missionTimer += Time.deltaTime;
            ScoreUpdate();

            if (!IsWhistle)
            {
                _whistleGauge.AddSteam(_addspeed, false);
                _fireBox.DecreaseFire(_decreaseFire);
            }
            else if(IsWhistle)
            {
                _whistleGauge.AddSteam(_decreaseSpeed, true);
            }

            if (_stageTimer >= _stageChangeTime)
            {
                _stageTimer = 0;
                //ステージ切り替え
                int index = Random.Range(0, 4);
                StageType nextStage = (StageType)index;
                StageChange(nextStage);
            }

            if(_missionTimer >= _missionTime)
            {
                _missionTimer = 0;
                _missionManager.StartMission((MissionType)Random.Range(0, 2));
                _isMission = true;
            }

            if(_fireBox.CurrntFire % 10 == 0)
            {
                SoundManager.Instance.PlaySE(SEType.Kati);
            }
        }
        else
        {
            if (_isDisplay) return;
            _deathTimer += Time.deltaTime;
            if(_deathTimer >= _deathTime)
            {
                SoundManager.Instance.PlayBGM(BGMType.Result);
                _scoreManager.DisplayResult(_deathType);
                _deathTimer = 0;
                _isDisplay = true;
            }            
        }

        if (_fireBox.CurrntFire <= 1)
        {
            _deathType = DeathType.Stop;
            _deathTime = 0.5f;
            IsDead = true;
        }
        else if (_fireBox.CurrntFire >= 100)
        {
            _deathType = DeathType.OverHeat;
            SoundManager.Instance.PlaySE(SEType.Explosion);
            OverHeatDeadAnimation();
            _fireBox.SetFire(2);
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
  
    public void FinishMission(bool isClear,DeathType deathType)
    {
        _isMission = false;
   
        if (!isClear)
        {
            IsDead = true;
            _deathType = deathType;
            Instantiate(_eventParticle, _eventParticleParent);
            _fireBox.SetFire(2);
            _fireBox.SetFire(1.1f);
        }
        _missionManager.EndMission();
    }

    public void ChangeWhistleState(bool toState)
    {
        IsWhistle = toState;
    }

    private void OverHeatDeadAnimation()
    {
        Instantiate(_particle, _particleParent);
        _fireBox.SetFire(2);
    }
    public void CountDownAnimation()
    {
        Sequence seq = DOTween.Sequence();

        _countText.gameObject.SetActive(true);
        int count = 3;

        seq.AppendCallback(() =>
        {
            _countText.text = count.ToString();
            _countText.transform.localScale = Vector3.zero;
        });

        seq.Append(_countText.transform.DOScale(1f, 0.3f)
            .SetEase(Ease.OutBack));

        seq.AppendInterval(0.5f);

        seq.AppendCallback(() =>
        {
            count = 2;
            _countText.text = count.ToString();
            _countText.transform.localScale = Vector3.zero;
        });

        seq.Append(_countText.transform.DOScale(1f, 0.3f)
            .SetEase(Ease.OutBack));

        seq.AppendInterval(0.5f);

        seq.AppendCallback(() =>
        {
            count = 1;
            _countText.text = count.ToString();
            _countText.transform.localScale = Vector3.zero;
        });

        seq.Append(_countText.transform.DOScale(1f, 0.3f)
            .SetEase(Ease.OutBack));

        seq.AppendInterval(0.5f);

        seq.AppendCallback(() =>
        {
            _countText.text = "START!!";
            _countText.transform.localScale = Vector3.zero;
        });

        seq.Append(_countText.transform.DOScale(1f, 0.4f)
            .SetEase(Ease.OutBack));

        seq.AppendInterval(0.5f);

        seq.Append(_countText.DOFade(0f, 0.3f));

        seq.OnComplete(() =>
        {
            _countText.gameObject.SetActive(false);

            _countText.alpha = 1f;

            _isCount = false;
        });
    }
}
