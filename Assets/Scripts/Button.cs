using UnityEngine;

public class Button : MonoBehaviour
{
    Animator animator;
    public static bool isOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.Play("Button_Down");
        isOpen = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        animator.Play("Button_Up");
        isOpen = false;
    }
}
