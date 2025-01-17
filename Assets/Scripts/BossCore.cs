using UnityEngine;

public class BossCore : MonoBehaviour
{
    public float health;

    private GameManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if(manager)
        {
            Debug.Log("Manager Found");
        }
        else
        {
            Debug.Log("Manager Not Found");
        }
    }

    public void Damage(float damage)
    {
        this.health -= damage;
        Debug.Log("Damaged Boss");
        if(this.health <= 0)
        {
            Debug.Log("Boss is Dead");
            if(manager)
            {
                manager.BossIsDead();
            }
            Destroy(gameObject);
        }
    }
}
