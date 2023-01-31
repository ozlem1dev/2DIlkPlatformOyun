using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 3f; //Edit�rde d�zenleyebilmek i�in SerializeField ekledik.
    [SerializeField] private float jumpForce = 400f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private bool grounded;
    private bool gameStarted;
    private bool jumping;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        grounded = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameStarted && grounded)
            {
                _animator.SetTrigger(name: "JumpClick");
                grounded = false;
                jumping = true;
            }
            else
            {
                _animator.SetBool(name: "GameStarted", value: true); //�lk Space bas���m�zda oyun ba�layacak. Z�plama olmayacak.
                gameStarted = true; //Oyun ba�lama de�i�keni.
            }
        }

        _animator.SetBool(name: "Grounded", grounded);

    }

    private void FixedUpdate()
    {
        if (gameStarted)
        {
            _rigidbody2D.velocity = new Vector2(x: speed, y: _rigidbody2D.velocity.y); //H�z de�i�ken de�il, sabit.
        }

        if (jumping)
        {
            _rigidbody2D.AddForce(new Vector2(x: 0f, y: jumpForce));
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = true;
        }
    }
}
