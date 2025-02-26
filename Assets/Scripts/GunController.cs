using UnityEngine;

public class GunController : MonoBehaviour
{
   public Transform gunTip;
   public GameObject bulletPrefab;
   public float bulletSpeed = 20f;
   public GameObject muzzleFlashPrefab;

   private void Update()
   {
      // User press left mouse-click
      if (Input.GetButtonDown("Fire1"))
      {
         
      }
   }

   public void Shoot()
   {
      // Muzzle flash when gunshot
      if (muzzleFlashPrefab != null)
      {
         Instantiate(muzzleFlashPrefab, gunTip.position, gunTip.rotation);
      }
      // Bullet spawns at the guntip after user fire gun
      GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);
      Rigidbody rb = bullet.GetComponent<Rigidbody>();
      if (rb != null)
      {
         rb.linearVelocity = gunTip.forward * bulletSpeed; // Send bullet forward
      }
      
      // Destroys the bullet after secons to save resources
      Destroy(bullet, 3f);
   }
}
