using UnityEngine;

public class Mimic : MonoBehaviour
{

    Rigidbody2D enemyRb;

    float moveSpeed = 200.0f;

    [SerializeField] float direction;

    void start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (direction == 1 )
            
    }


}
