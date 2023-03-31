using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushableBox : MonoBehaviour
{
    public float pushForce = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        if (movement.magnitude > 0f)
        {
           
            rb.AddForce(movement * pushForce, ForceMode.Impulse);
        }
    }
}
