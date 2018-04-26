using UnityEngine;

// Class for Action Bar
public class Action : MonoBehaviour {
    public Animator animator;

    // Open the Action Bar after player rolled the dice
    public void Open()
    {
        animator.SetBool("isOpen", true);
    }

    // Close the Action Bar after player chose to end turn
    public void Close()
    {
        animator.SetBool("isOpen", false);
    }
}
