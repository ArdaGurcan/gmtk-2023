using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundBackgroundSwap : MonoBehaviour
{
    
    public GameObject player;
    CharacterController2D p_controller;

    private bool foreground = true;
    
    // Start is called before the first frame update
    void Start()
    {
      p_controller = player.GetComponent<CharacterController2D>();
      p_controller.m_WhatIsGround = LayerMask.GetMask("Foreground", "Ground");

      GameObject[] objs = GameObject.FindGameObjectsWithTag("Foreground");
      foreach(GameObject o in objs) { // iter through all GameObjects with certain tag
          BoxCollider2D[] colliders = o.GetComponents<BoxCollider2D>();
          foreach(BoxCollider2D collider in colliders) {
              if(collider != null)
                  collider.enabled = true; // toggle colliders
          }
      }


      objs = GameObject.FindGameObjectsWithTag("Background");
      foreach(GameObject o in objs) { // iter through all GameObjects with certain tag
          BoxCollider2D[] colliders = o.GetComponents<BoxCollider2D>();
          foreach(BoxCollider2D collider in colliders) {
              if(collider != null)
                  collider.enabled = false; // toggle colliders
          }
        }
      Debug.Log(p_controller);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Swap")) {
         if(foreground) {
            p_controller.m_WhatIsGround = LayerMask.GetMask("Background", "Ground");
            toggleCollider("Foreground", "Background");
            foreground = false;
         } else {
            p_controller.m_WhatIsGround = LayerMask.GetMask("Foreground", "Ground");
            toggleCollider("Foreground", "Background");
            foreground = true;
         }
       }
    }

    private void toggleCollider(params string[] tags) {
        foreach(string tag in tags) {
            GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);
            foreach(GameObject o in objs) { // iter through all GameObjects with certain tag
                BoxCollider2D[] colliders = o.GetComponents<BoxCollider2D>();
                foreach(BoxCollider2D collider in colliders)
                    if(collider != null)
                        collider.enabled = !collider.enabled; // toggle colliders
            }
        }
    }

}
