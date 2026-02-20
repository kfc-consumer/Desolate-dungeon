using UnityEngine;


public class PlayerWeaponScript : MonoBehaviour
{
    private float AttackCdTime;
    public float StartAttackCdTime;
    public Transform attackPos;
    public float AttackRange;
    public LayerMask whatIsEnemies;
    public int Damage;
    TestEnemy2 Enemy;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Enemy = FindAnyObjectByType<TestEnemy2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AttackCdTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, AttackRange, whatIsEnemies);
                for (int i = 0; i < EnemiesToDamage.Length; i++)
                    {
                    EnemiesToDamage[i].GetComponent<TestEnemy2>().TakeDamage(Damage);
                }



            }
            AttackCdTime = StartAttackCdTime;


        }
        else
        {
            AttackCdTime -= Time.deltaTime;
        }
    }
}
