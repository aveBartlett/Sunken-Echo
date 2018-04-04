using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {

    public float speed;
    Vector2 inputForce;

    Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        float verticalMove = Input.GetAxis("Vertical");
        float horizontalMove = Input.GetAxis("Horizontal");

        //adds the force
        inputForce = new Vector2(horizontalMove, verticalMove);
        inputForce = inputForce * speed;

        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("Walking", true);
        } else
        {
            animator.SetBool("Walking", false);
        }
    }

    // Update is called once per frame
    //handles the physics
    void FixedUpdate () {
        //finds mouse position
        Vector3 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion playerRotation = Quaternion.LookRotation(transform.position - mousePostion, Vector3.forward);
        
        //makes the player look
        transform.rotation = playerRotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 180);
        this.GetComponent<Rigidbody2D>().angularVelocity = 0;

        this.GetComponent<Rigidbody2D>().AddForce(inputForce);
    }
}
