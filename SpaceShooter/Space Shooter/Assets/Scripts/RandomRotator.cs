using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    private Rigidbody rb;

    public float Tumble;

	// Use this for initialization
	void Start ()
	{
	    rb = GetComponent<Rigidbody>();
        //point inside unit sphere gives us a random vector3
	    rb.angularVelocity = Random.insideUnitSphere*Tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
