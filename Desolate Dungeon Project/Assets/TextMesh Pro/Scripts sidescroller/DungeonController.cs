using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    Vector2 StartPosition;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private GameObject deathEffect;


    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TestEnemy"))
        {
            Die();
        }
    }

    private void DeathParticles()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

    }

        
    void Die()
    {
        StartCoroutine(Respawn(0.5f));
        DeathParticles();
        
    }

    IEnumerator Respawn(float duration)
    {
        rb.simulated = false;
        rb.linearVelocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = StartPosition;
        transform.localScale = new Vector3(1, 1, 1);
        rb.simulated = true;
    }

   
}
