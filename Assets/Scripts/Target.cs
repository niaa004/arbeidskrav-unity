using UnityEngine;

public class Target : MonoBehaviour
{
    public bool isTargetHit;
    public float health = 50f;
    public float defaultHealth;
    
   
    private void Start()
    {
        defaultHealth = health;
    }
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (isTargetHit)
        {
            health = defaultHealth;
        }
        else
        {
            Destroy(gameObject);
        }

        Debug.LogError("Target Down!");
    }
}
