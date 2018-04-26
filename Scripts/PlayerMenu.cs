using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for player menu
public class PlayerMenu : MonoBehaviour {
    public Animator animator;

    // Open the player menu
    public void Open()
    {
        animator.SetBool("isOpen", true);
    }

    // Close the player menu
    public void Close()
    {
        animator.SetBool("isOpen", false);
    }

}
