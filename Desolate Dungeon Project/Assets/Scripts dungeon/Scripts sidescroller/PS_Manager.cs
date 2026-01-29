using UnityEngine;

public class PS_Manager : MonoBehaviour
{
    public int PlayerHealthPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    public void TakeDamage(int damage)
    {
        PlayerHealthPoints -= damage;
        HPCondition();

    }

    public void HPCondition()
    {
        if (PlayerHealthPoints <= 0)
        {
            Debug.Log("Player Dead");
        }
    }

}
        
        
        
        
        
