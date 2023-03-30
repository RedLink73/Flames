
using UnityEngine;

public class DissolveOnCollision : MonoBehaviour
{
    public Material dissolveMaterial;

    public void Start()
    {
        Material dissolveMaterial = GetComponent<Renderer>().material;
        dissolveMaterial.SetFloat("_DissolveAmount", 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        float t = 0;
        if (other.CompareTag("Fire"))
        {
            t -= Time.deltaTime / 2f;
            Material dissolveMaterial = GetComponent<Renderer>().material;
            dissolveMaterial.SetFloat("_DissolveAmount", 2.0f);
        }
    }
}