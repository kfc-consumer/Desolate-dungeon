using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileLaunch : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform launchPoint;

    public float shootTime;     // cooldown between projectiles
    public float shootCounter;  // cooldown timer


    void Start()
    {
        shootCounter = shootTime; // starts countdown when you start the game

    }

    
    void Update()
    {
        
        if (Input.GetButtonDown("Left button") && shootCounter <= 0)
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
            
            
        }
        shootCounter = Time.deltaTime;
    }
}
