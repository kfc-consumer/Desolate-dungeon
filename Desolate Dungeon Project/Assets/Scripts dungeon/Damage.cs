using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Damage : MonoBehaviour
{

    public int damage = 2;
    private Health playerHealth;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           if (playerHealth == null)
           {
                playerHealth = collision.gameObject.GetComponent<Health>();
           }
            
            playerHealth.TakeDamage(damage);
        }


    }

}
