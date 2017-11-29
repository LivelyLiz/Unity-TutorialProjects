using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject Explosion;
    public GameObject PlayerExplosion;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Boundary"))
            return;
        //Destroy Bolt
        Destroy(other.gameObject);
        //Destroy this asteroid
        Destroy(gameObject);

        Instantiate(Explosion, transform.position, Quaternion.identity);
        if (other.tag.Equals("Player"))
        {
            Instantiate(PlayerExplosion, other.transform.position, Quaternion.identity);
        }
    }
}
