using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    Animator _animator;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Asyncs.Delay(Fall, 0.25f);
            _animator.SetTrigger("Fall");
        }
    }

    void Fall()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        Destroy(this);
        Destroy(gameObject, 3f);
    }
}
