using System.Collections;
using UnityEngine;

public class DissolveOnCollision : MonoBehaviour
{
    public Material dissolveMaterial;
    public float dissolveTime = 1f;

    private Collider objectCollider;

    private void Start()
    {
        objectCollider = GetComponent<Collider>();
        dissolveMaterial.SetFloat("_DissolveAmount", 0f);
    }

    private IEnumerator DissolveCoroutine()
    {
        float t = 0f;
        while (t < dissolveTime)
        {
            t += Time.deltaTime;
            dissolveMaterial.SetFloat("_DissolveAmount", t / dissolveTime);
            yield return null;
        }

        // Disable the collider component after the dissolve is complete
        objectCollider.enabled = false;

        // Destroy the game object after the dissolve is complete
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            StartCoroutine(DissolveCoroutine());
        }
    }
}

