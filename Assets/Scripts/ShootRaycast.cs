using UnityEngine;

public class ShootRaycast : MonoBehaviour
{
    public Camera playerCamera;
    public Light gunfireLight;
    
    public float range = 100f;
    public float damage = 10f;
    public float firingRate = 15f;
    private float firingTimer = 0f;
    private float lightDuration = 0.1f;
    private float lightTimer = 0f;
    
    private void Start()
    {
        playerCamera = Camera.main;
        gunfireLight = transform.Find("GunfireLight").GetComponent<Light>();

        if (gunfireLight == null)
        {
            Debug.LogError("GunfireLight not found on 'GunfireLight'! Please ensure there is a light component.");
        }
        
        gunfireLight.enabled = false; // Starts with flash off
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > firingTimer)
        { firingTimer = Time.time + 1f / firingRate;
            Shoot();
            
            gunfireLight.enabled = true;
            lightTimer = Time.time + lightDuration;
        }
        
        if (gunfireLight.enabled && Time.time > lightTimer)
        {
            gunfireLight.enabled = false;
        }
    }
    
    

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Debug.LogError(hit.transform.name);

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * range);
            }

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}