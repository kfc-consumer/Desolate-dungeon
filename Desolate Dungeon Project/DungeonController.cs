using System.Collections;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    Vector2 StartPosition;
    Rigidbody PlayerRb;
    
    private void Awake()
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartPosition = transform.position;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TestEnemy"))
        {
            Die();
        }
    }


    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        PlayerRb.isKinematic = true;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = StartPosition;
        transform.localScale = new Vector3(1, 1, 1);
        PlayerRb.isKinematic = false;

    }


}
