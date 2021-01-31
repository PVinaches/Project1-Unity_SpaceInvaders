using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float initialLife = 4;
    public float damage = 1;
    public AudioClip destroySound;
    
    public static float life;
    public static float initLife;
    
    private Transform _enemy;
    private ScoreManager _scoreManager;


    // Declaring the initial state of the enemy
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Transform> () as Transform;
        life = initialLife;
        initLife = initialLife;
        _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // How the enemy moves
        _enemy.position += Vector3.up * speed * -1;
        
        // What happens when the enemy goes out of the limits of the game screen
        if (_enemy.position.y <= -7f){
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }

    // Killing the player or colliding with another enemy
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
            other.GetComponent<PlayerShip>().Shooted(damage);
        }
        else if (other.tag == "Enemy")
        {
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }

    // Enemy's life updated when collising with a projectile
    public void TakeDamage (int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            life = initLife;
            ObjectPool.SharedInstance.ReturnToPool(gameObject);

            // Reminiscent of option one to update the score display
            /* GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>().AddScore(); */
            
            // Option two to update the score display
            _scoreManager.IncrementalScore(1);

            // Destroy sound
            sfxController.SharedInstance.PlayClip(destroySound);
        }
    }
}
