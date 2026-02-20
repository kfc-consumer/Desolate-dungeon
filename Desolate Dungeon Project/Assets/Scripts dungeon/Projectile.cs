using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
public class Projectile : MonoBehaviour
{


    public Rigidbody2D projectileRb;
    public float speed;

    public float projectileLife;
    public float projectileCount;

   


    void Start()
    {
        projectileCount = projectileLife;
        
    }


    void Update()
    {

        projectileCount -= Time.deltaTime;
        if (projectileCount <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        projectileRb.linearVelocity = new Vector2(speed, projectileRb.linearVelocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weak Point")
        {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }

}
