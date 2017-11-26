using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 6f;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody PlayerRigidbody;
    private int floorMask;
    private float camRayLength = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    //Fixed Update runs each physics update not every render update
    void FixedUpdate()
    {
        //GetAxis "horizontal" default is ad and left, right arrow keys
        float h = Input.GetAxisRaw("Horizontal");
        //default w,s and up down arrow keys
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f ,v);
        movement = movement.normalized*Speed*Time.deltaTime;

        PlayerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        //shoot a ray in the scene, store result it in floorHit, ray should be of length camRayLength and it should only test for the floor layer
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            //player should not lean towards the floor
            playerToMouse.y = 0.0f;

            //make player to mouse our forward vector
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            //apply this as the new looking rotation
            PlayerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = (h != 0 || v != 0);
        anim.SetBool("IsWalking", walking);
    }
}
