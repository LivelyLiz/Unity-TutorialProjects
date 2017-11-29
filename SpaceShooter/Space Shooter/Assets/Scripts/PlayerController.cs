using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private AudioSource weaponPew;
    private float myTime;

    public float FireCooldown;
    public float Speed;
    public float Tilt;
    public Boundary Boundary;
    public Transform ShotSpawn;
    public GameObject Shot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        weaponPew = GetComponent<AudioSource>();
    }

    //called every frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > FireCooldown)
        {
            weaponPew.Play();
            /*GameObject newProjectile = */
            Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation) /*as GameObject*/;
            myTime = 0.0F;
        }
    }

    //will be executed once per physics step
    void FixedUpdate()
    {
        MoveShip();
        TiltShip();
        SetBackToBoundary();
    }

    void TiltShip()
    {
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -Tilt);
    }

    void MoveShip()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 speed = new Vector3(moveHorizontal * Speed, 0.0f, moveVertical * Speed);
        rb.velocity = speed;
    }

    void SetBackToBoundary()
    {
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, Boundary.xMin, Boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, Boundary.zMin, Boundary.zMax)
            );
    }
}
