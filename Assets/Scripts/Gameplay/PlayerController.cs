using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action OnShot;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private WeaponController weapon = null;
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private AudioClip shootClip = null;

    [Space(10)]
    [Header("Settings")]
    [SerializeField] private float speedAngular = 120;
    [SerializeField] private float speedLinear = 4f;
    [SerializeField] private float impulse = 2f;
    //[SerializeField] private float speedMax = 3.5f;
    
    private float inputV = 0f;
    private float inputH = 0f;
    private bool isShooting;

    private void OnEnable()
    {
        weapon.Suscribe(this);
    }

    private void OnDisable()
    {
        weapon.Unsuscribe(this);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        RotatePlayer();
        //MovePlayerTransform();

        if (isShooting)
        {
            audioSource.PlayOneShot(shootClip, 0.5f);
            OnShot?.Invoke();
        }
        
    }

    private void FixedUpdate()
    {
        MovePlayerRigidBody();
    }

    private void GetInput()
    {

        inputV = Input.GetAxis("Vertical");
        inputH = Input.GetAxis("Horizontal");

        isShooting = Input.GetButton("Fire1") || Input.GetButtonDown("Jump");
         
    }

    private void RotatePlayer()
    {
        var rotation = inputH * speedAngular * Time.deltaTime;
        gameObject.transform.Rotate(Vector3.back, rotation, Space.Self);
    }

    private void MovePlayerTransform()
    {
        var translation = inputV * speedLinear * Time.deltaTime * transform.up;
        gameObject.transform.Translate(translation, Space.World);
    }

    private void MovePlayerRigidBody()
    {
        if (inputV <= 0f) return;
        
        var direction = impulse * inputV * Time.deltaTime * transform.up;
        rb.AddForce(direction, ForceMode2D.Impulse);
    }

}
