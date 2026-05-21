using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class TrainView : MonoBehaviour
{

    [SerializeField] private Image _speedEffectImage;
    [SerializeField] private FireBox _fireBox;
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        SpeedEffect();

    }
    private void Move()
    {
        _rb.linearVelocity = Vector3.forward * _moveSpeed * _fireBox.CurrntFire;
    }
    private void SpeedEffect()
    {
        if (_fireBox == null || _speedEffectImage == null) return;
        _speedEffectImage.color = new Color(1, 1, 1, Mathf.Clamp01(_fireBox.CurrntFire / 100f));
    }
}
