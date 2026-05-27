using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class TrainView : MonoBehaviour
{

    [SerializeField] private Image _speedEffectImage;
    [SerializeField] private FireBox _fireBox;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private ParticleSystem _particleSystem;

    private GameManager _gameManager;
    private Rigidbody _rb;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogWarning($"è’ìÀ: {collision.gameObject.name}");
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _rb = GetComponent<Rigidbody>();
        _particleSystem.Stop();
    }

    private void FixedUpdate()
    {
        if (_gameManager.IsDead)
        {
            _rb.linearVelocity = Vector3.zero;
            return;
        }

        Move();
        SpeedEffect();
        if (_gameManager.IsWhistle)
        {
            if(!_particleSystem.isPlaying)
                _particleSystem.Play();
        }
        else
        {
            if (_particleSystem.isPlaying)
                _particleSystem.Stop(true,ParticleSystemStopBehavior.StopEmitting);
        }
    }
    private void Move()
    {
        _rb.linearVelocity = Vector3.forward * _moveSpeed * _fireBox.CurrntFire;
    }
    private void SpeedEffect()
    {
        if (_fireBox == null || _speedEffectImage == null) return;
        _speedEffectImage.color = new UnityEngine.Color(1, 1, 1, Mathf.InverseLerp(50f, 100f, _fireBox.CurrntFire));
    }
}
