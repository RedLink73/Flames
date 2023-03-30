using UnityEngine;

public class Burn : MonoBehaviour
{
    public GameObject flameLight;

    public void Start()
    {
        flameLight.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torch"))
        {
            flameLight.SetActive(true);
        }
    }
}