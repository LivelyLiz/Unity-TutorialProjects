using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private int count_Collectables = 0;

    public float Speed;
    public Text Count_Text;
    public Text Win_Text;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText();
        Win_Text.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * Speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count_Collectables++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        Count_Text.text = "Count: " + count_Collectables.ToString();
        if (count_Collectables >= 11)
        {
            Win_Text.text = "You WIN";
        }
    }

}
