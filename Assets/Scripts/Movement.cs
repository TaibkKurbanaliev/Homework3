using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private bool _canJump;
    private Animator _animatitor;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animatitor = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animatitor.SetBool("IsRun",true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * -Time.deltaTime, 0, 0);
            _animatitor.SetBool("IsRun", true);
        }
        else
        {
            _animatitor.SetBool("IsRun", false);
        }
        
        if (_canJump && Input.GetKey(KeyCode.Space))
        {
            _canJump = false;
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            _animatitor.SetTrigger("Jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _canJump = true;
        }
    }
}
