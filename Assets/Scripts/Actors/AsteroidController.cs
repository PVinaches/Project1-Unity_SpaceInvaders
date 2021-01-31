using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed;

    private Transform _asteroid;
    
    // Start is called before the first frame update
    void Start()
    {
        _asteroid = GetComponent<Transform> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // How the asteroid moves
        _asteroid.position += Vector3.up * speed * -1;
        
        // What happens when the asteroid goes out of the limits of the game screen
        if (_asteroid.position.y <= -9f){
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }

    // Killing the player or colliding with an enemy
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().EndGame();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Enemy")
        {
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }
}
