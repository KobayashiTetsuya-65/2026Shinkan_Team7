using UnityEngine;

public class Stone : MonoBehaviour
{
    public Rigidbody rb;

    public float power = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(0f, 5f, 10f, ForceMode.Impulse);
        }
    }
}