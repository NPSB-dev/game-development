using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.freezeMovement)
        {
            animator.SetBool(isWalkingHash, false);
            return;
        }

        bool movingKeyPressed = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        bool isWalking = animator.GetBool(isWalkingHash);

        if (movingKeyPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        
        if (!movingKeyPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }
    }
}
