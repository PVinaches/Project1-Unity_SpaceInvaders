using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShip : MonoBehaviour
{
    public float speed = 1f;
    public float initialLife = 4;

    public static float life;
    public static float initLife;

    private Rigidbody2D _rb;
    private Vector2 _minCamera;
    private Vector2 _maxCamera;
    private Vector2 _inputDirection;

    // Reminiscent of option one of score displayer
    /* public int score = 0; */

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _minCamera = CameraExtensions. BoundsMin(Camera.main);
        _maxCamera = CameraExtensions. BoundsMax(Camera.main);

        life = initialLife;
        initLife = initialLife;
    }

    // Update is called once per frame
    // To detect the input (i.e. mouse, keyboard)
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _inputDirection =input.normalized;
    }

    // To actually move the object
    void FixedUpdate()
    {
        if (BoundsCheck(_inputDirection))
        {
            _rb.MovePosition(_rb.position + _inputDirection * Time.fixedDeltaTime * speed);
        }
    }

    // So we can check the limits of the movement
    private bool BoundsCheck(Vector2 input)
    {
        Vector2 toPos = new Vector2(transform.position.x, transform.position.y) + input  * 0.1f;
        return toPos.x > _minCamera.x && toPos.x < _maxCamera.x && toPos.y > _minCamera.y && toPos.y < _maxCamera.y;
    }

    // Bonus increasing life
    public void BonusLife(float bonus)
    {
        if (initialLife >0 && initialLife < 4)
        {
            initialLife += bonus;
        }
    }

    // Killing the player with enemy damage
    public void Shooted(float damage)
    {
        if (initialLife >0 && initialLife > damage)
            initialLife -= damage;
        else
        {
            initialLife = 0;
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    // Reminiscent of option one of score displayer
    /* public void AddScore()
    {
        score += 1;
    } */
}