using System.Collections;
using UnityEngine;

public class DeactivateTimer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestroySelf());  
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
