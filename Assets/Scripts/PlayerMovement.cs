using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")) {
          jump = true;
          animator.SetBool("Jumping",true);
        }
    }

    void FixedUpdate() {
      controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
      jump = false; 
    }

    void OnCollisionEnter2D(Collision2D col) {
      if(col.gameObject.layer == LayerMask.NameToLayer("Ground") 
          || col.gameObject.layer == LayerMask.NameToLayer("Background")
          || col.gameObject.layer == LayerMask.NameToLayer("Foreground")) {
        animator.SetBool("Jumping", false);
      }
    }


}
