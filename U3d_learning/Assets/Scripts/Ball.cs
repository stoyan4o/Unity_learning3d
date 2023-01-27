using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float _speed = 20f;
    Rigidbody _rigidbody;
    Vector3 _velocity;  // speed with direction

    void Start()
    {
        /*
         * Vector3.
         *      forward = 0,0,1,
         *      back 0,0,-1
         *      
         */
        Vector3 direction = new Vector3(0, 0, -1);

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = direction * _speed;    // at the beginning the ball should drop DOWN
    }

    // Update is called once per frame
    void Update()
    {
        // runs every frame
    }

    void FixedUpdate()
    {
        // for physics I should use this. Runs 100 per second
        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        _velocity = _rigidbody.velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // in _velocity we have the speed before the collision
        _rigidbody.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);

        // GlobalVars.Instance.a = 1;
    }
}
