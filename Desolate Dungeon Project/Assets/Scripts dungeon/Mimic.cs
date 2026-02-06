using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Mimic : MonoBehaviour
{
    Rigidbody2D enemyRb;

   [SerializeField] Transform playerRb;

   [SerializeField] float moveSpeed;

   [SerializeField] float direction;

   [SerializeField] float attackRange = 5f;

   [SerializeField] LayerMask groundLayer;
   [SerializeField] float checkDistance;


    [SerializeField] Transform lookPosition;

    

    void Start()
    {
     enemyRb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, playerRb.position);

        

        if (distanceToPlayer <= attackRange)
        {
            attack();
            
        }

        // if (direction == 1) //
        // {
        // eller transform.localScale = Vector3.one * moveSpeed;
        // transform.localScale = new Vector3(-1, 1, 1);
        //}else if (direction == -1) 
        //  {
        // transform.localScale = new Vector3(1, 1, 1);
        //  }

        enemyRb.linearVelocity = new Vector2(direction * moveSpeed * Time.deltaTime, enemyRb.linearVelocity.y);

        RaycastHit2D hit = Physics2D.Raycast(lookPosition.position, Vector2.down, checkDistance, groundLayer);

       

    }

    void attack()
    {
        if(playerRb.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }


            transform.position = Vector2.MoveTowards(transform.position, playerRb.position, moveSpeed * Time.deltaTime);


    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        direction *= -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        direction *= -1;
    }

}
