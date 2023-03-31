using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public float pickUpDistance = 3f; // the maximum distance at which the object can be picked up
    public LayerMask pickUpLayerMask; // the layers that the player can pick up objects from
    public Transform handTransform; // the transform representing the player's hand

    private Rigidbody rb;
    private bool isBeingCarried = false;
    private Transform originalParent;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        // check if the object is being carried
        if (isBeingCarried)
        {
            // move the object with the player's hand
            transform.position = handTransform.position;
            transform.rotation = handTransform.rotation;

            // rotate the object by 45 degrees around the X axis
            transform.localRotation *= Quaternion.Euler(55f, 10f, 0f);
        }
        else
        {
            // check if the player is close enough to pick up the object
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickUpDistance, pickUpLayerMask))
            {
                // show a prompt to pick up the object
                Debug.Log("Press E to pick up the object");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // pick up the object
                    isBeingCarried = true;
                    rb.isKinematic = true;
                    transform.SetParent(handTransform);
                }
            }
        }

        // drop the object if it's being carried and the player presses the drop key
        if (isBeingCarried && Input.GetKeyDown(KeyCode.Q))
        {
            isBeingCarried = false;
            rb.isKinematic = false;
            //transform.SetParent(originalParent);
            transform.localPosition = originalPosition;
            transform.localRotation = originalRotation;
        }
    }
}
