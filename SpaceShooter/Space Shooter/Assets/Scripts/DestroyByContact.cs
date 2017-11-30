using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public int ScoreValue;
    public GameObject Explosion;
    public GameObject PlayerExplosion;

    private GameController gameCon;

    void Start()
    {
        GameObject gc = GameObject.FindGameObjectWithTag("GameController");

        if (gc != null)
        {
            gameCon = gc.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find 'GameController' Script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Boundary"))
            return;

        gameCon.AddScore(ScoreValue);
        //Destroy Bolt
        Destroy(other.gameObject);
        //Destroy this asteroid
        Destroy(gameObject);

        Instantiate(Explosion, transform.position, Quaternion.identity);
        if (other.tag.Equals("Player"))
        {
            Instantiate(PlayerExplosion, other.transform.position, Quaternion.identity);
            gameCon.GameOver();
        }
    }
}
