using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impactEffect; 

    private void OnTriggerEnter(Collider other)
    {
        // checks if the bullet hit the target
        if (other.CompareTag("Target"))
        {
            Debug.Log("Target hit!");

            // spawns effect
            if (impactEffect != null)
            {
                Instantiate(impactEffect, transform.position, Quaternion.identity);
            }

            // destroys the target
            Destroy(other.gameObject);

            // breaks bullet after hit
            Destroy(gameObject);
        }
    }
}