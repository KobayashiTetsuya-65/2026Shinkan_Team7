using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TrainMove : MonoBehaviour
{
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
    }
    private void Move()
    {
        _rb.linearVelocity = Vector3.forward * _moveSpeed * _fireBox.CurrntFire;
    }
}
