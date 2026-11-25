using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    private static bool doorOpen;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        doorOpen = Button.isOpen;

        if (doorOpen)
        {
            animator.SetBool("isOpening", true);
        }
        else
        {
            animator.SetBool("isOpening", false);
        }
    }
}
