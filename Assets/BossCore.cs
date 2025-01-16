using UnityEngine;

public class BossCore : MonoBehaviour
{
    public float health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        this.health -= damage;
        if(this.health <= 0)
        {
            Debug.Log("Boss is Dead");
        }
    }
}
