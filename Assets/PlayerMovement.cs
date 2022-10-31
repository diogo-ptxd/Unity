using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    void Start()
    {
    }
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpforce = 200;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] public float RunSpeed = 10;
    [SerializeField] public float NormalSpeed = 5;
    public bool isRunning = false;
    private float canJump = 0f;
    void Update()
    {
        var vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;
        vel.y = _rb.velocity.y;
        _rb.velocity = vel;
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canJump) { _rb.AddForce(Vector3.up * _jumpforce); canJump = Time.time + 1.0f;}
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            _speed = RunSpeed;
        }
        else
        {
            isRunning = false;
            _speed = NormalSpeed;
        }
    }
}