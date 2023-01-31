using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 3f; //Editörde düzenleyebilmek için SerializeField ekledik.
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
                _animator.SetBool(name: "GameStarted", value: true); //Ýlk Space basýþýmýzda oyun baþlayacak. Zýplama olmayacak.
                gameStarted = true; //Oyun baþlama deðiþkeni.
            }
        }

        _animator.SetBool(name: "Grounded", grounded);

    }

    private void FixedUpdate()
    {
        if (gameStarted)
        {
            _rigidbody2D.velocity = new Vector2(x: speed, y: _rigidbody2D.velocity.y); //Hýz deðiþken deðil, sabit.
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
