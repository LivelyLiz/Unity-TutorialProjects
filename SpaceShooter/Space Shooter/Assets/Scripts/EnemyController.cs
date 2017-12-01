using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody rb;
    private AudioSource weaponPew;
    private float myTime;

    public float FireCooldown;
    public float Speed;
    public Transform ShotSpawn;
    public GameObject Shot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        weaponPew = GetComponent<AudioSource>();
        rb.velocity = transform.forward * Speed;
    }

    //called every frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (myTime > FireCooldown)
        {
            weaponPew.Play();
            Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
            myTime = 0.0F;
        }
    }
}
