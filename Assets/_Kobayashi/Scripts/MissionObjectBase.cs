using UnityEngine;

public abstract class MissionObjectBase : MonoBehaviour,IObjectMission
{
    public bool IsCorrect => _isCorrect;
    public float CorrentValue => _correctValue;
    [SerializeField,Header("Ž€ˆöÝ’è")]
    private DeathType _deathType;
    [Header("-----¬Œ÷”»’è-----")]
    [SerializeField] private bool _isUpper = true;
    [SerializeField] private float _correctValue;
    private bool _isCorrect = false;
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = GameManager.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_gameManager == null) _gameManager = GameManager.Instance;
            float value = _gameManager.FireBox.CurrntFire;
            if (_isUpper)
            {
                _isCorrect = value >= _correctValue;
            }
            else
            {
                _isCorrect = value <= _correctValue;
            }

            if(_isCorrect)
                CrearAnimation();
            else
            {
                SoundManager.Instance.PlaySE(SEType.Explosion);
                //Ž¸”s
            }

            _gameManager.FinishMission(_isCorrect,_deathType);
        }
    }

    public virtual void CrearAnimation()
    {
        Debug.Log("“Ë”jIII");
    }
}
