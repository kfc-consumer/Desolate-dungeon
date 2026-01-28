using UnityEngine;

public class Mimic : MonoBehaviour
{

    Rigidbody2D mimicRb;
    
    [SerializeField] float moveSpeed;
    Transform target;
    Vector3 moveDirection;

    private void Awake()
    {
        mimicRb = GetComponent<Rigidbody2D>();

    }

    

    void start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (target)
        {
            Vector3 = (target.position - transform.position).normalized.moveDirection;
        }
    }

}
