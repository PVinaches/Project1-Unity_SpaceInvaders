using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Power up projectiles
public class NewProjectiles : MonoBehaviour
{
    /* private Transform newProjectile; */
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        // How the projectile moves
        transform.position += Vector3.up * speed * -1;
        
        // What happens when the projectile goes out of the limits of the game screen
        if (transform.position.y <= -7f){
            /* ObjectPool.SharedInstance.ReturnToPool(gameObject); */
            Destroy(gameObject);
        }
    }

    // Activating projectile in player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           other.GetComponent<ShipShooter>().PowerUp(tag);
           Destroy(gameObject);
        }
    }
}