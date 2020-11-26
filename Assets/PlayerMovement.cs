using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f; // The Movement Speed (Left and Right) value
    float horizontalMove = 0f; // Keeps track of hozontal direction movement value (1, right or left, -1)

    bool jump = false; // Keeps track of jump state

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("IsJumping", jump);
        }
    }

    public void OnLand() {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate() {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
