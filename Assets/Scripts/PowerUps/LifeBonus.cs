using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonus : MonoBehaviour
{
    public float speed;
    public float bonusValue = 1;

    public static float bonus;

    private Transform _lives;
    
    // Declaring the initial state of the bonus
    // Start is called before the first frame update
    void Start()
    {
        _lives = GetComponent<Transform> ();
        bonus = bonusValue;       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // How the lifeBonus moves
        _lives.position += Vector3.up * speed * -1;
        
        // What happens when the bonus goes out of the limits of the game screen
        if (_lives.position.y <= -8f){
            /* ObjectPool.SharedInstance.ReturnToPool(gameObject); */
            Destroy(gameObject);
        }
    }

    // Taking the bonus
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            other.GetComponent<PlayerShip>().BonusLife(bonus);
        }
    }
}
