using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TrainMove : MonoBehaviour
{
    [SerializeField] private FireBox _fireBox;
    [SerializeField] private float _moveSpeed = 1f;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        _rb.linearVelocity = Vector3.down * _moveSpeed * _fireBox.CurrntFire * Time.deltaTime;
    }
}
