using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipProjectile : MonoBehaviour
{
    public int damage = 1;
    public float speed = 1f;
    public float rate = 1f;
    public float limite = 2f;

    [HideInInspector]
    public GameObject shooter;

    // Define the movement of the projectile and when it has to be destroyed (moved back to the pool)
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * speed, Space.World);
        if (transform.position.y >= limite)
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
    }

    // To destroy the enemies when shooted
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().TakeDamage(damage);
            
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
        
        else if (other.tag == "Asteroid")
        {
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }
}
