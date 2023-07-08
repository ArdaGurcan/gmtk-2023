using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBounce : MonoBehaviour
{
    public Animator animator;
    CharacterController2D p_controller;
    Vector3 p_pos;
    Vector3 mushroom_top;

    public GameObject player;
    private string p_tag;

    public int jump_multiplier = 2;
    private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        p_tag = player.tag;
        p_pos = player.transform.position;
        p_controller = player.GetComponent<CharacterController2D>();
        jumpForce = p_controller.m_JumpForce;

        mushroom_top = this.transform.GetChild(0).transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        p_pos = player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D col) {
        Vector3 delta_pos = p_pos - mushroom_top;

        // Check if player is above mushroom during collision
        if(col.gameObject.tag.Equals(p_tag) && delta_pos.y > 0) {
            p_controller.m_JumpForce *= jump_multiplier;
            animator.SetBool("Bounce", true);
        }
    }

    private void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag.Equals(p_tag)) {
            animator.SetBool("Bounce", false);
            p_controller.m_JumpForce = jumpForce; // Reset Jumpforce
        }
    }
}
