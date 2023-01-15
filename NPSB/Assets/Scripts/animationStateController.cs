using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isSucceedingBackflipHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isSucceedingBackflipHash = Animator.StringToHash("isSucceedingBackflip");
    }

    // Update is called once per frame
    void Update()
    {
        print(Globals.isSucceedingBackflip);
        if (Globals.freezeMovement)
        {
            animator.SetBool(isWalkingHash, false);
            return;
        }

        bool movingKeyPressed = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        bool isWalking = animator.GetBool(isWalkingHash);
        int isSucceedingBackflip = animator.GetInteger(isSucceedingBackflipHash);

        if (movingKeyPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        
        if (!movingKeyPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        //if (Globals.isSucceedingBackflip != 0 && isSucceedingBackflip == 0){
            animator.SetInteger(isSucceedingBackflipHash, Globals.isSucceedingBackflip);
        //}

        /*if (!spaceKeyPressed && isSucceedingBackflip != 0)
        {
            animator.SetInteger(isSucceedingBackflipHash, isSucceedingBackflip);
        }*/
    }
}
