using UnityEngine;

public class PushYZ : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float yPower = 5f;

    [SerializeField]
    private float zPower = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Y方向とZ方向へ力を加える
        Vector3 force = new Vector3(0, yPower, zPower);

        rb.AddForce(force, ForceMode.Impulse);
        
    }
}
