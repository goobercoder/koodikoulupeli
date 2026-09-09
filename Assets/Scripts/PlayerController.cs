using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    SpriteRenderer spriteRenderer;
    BoxCollider boxCollider;

    bool isGrounded;
    [SerializeField] LayerMask groundLayer; //mihin kerrokseen maa kuuluu

    public float fallMultiplier = 2.5f;
    public float speed = 10f;
    public float jumpVelocity = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float extraHeight = 0.1f;

        bool centerRay = Physics.Raycast(boxCollider.bounds.center, Vector3.down, boxCollider.bounds.extents.y + extraHeight, groundLayer);
        bool minRay = Physics.Raycast(boxCollider.bounds.min, Vector3.down, boxCollider.bounds.extents.y + extraHeight, groundLayer);
        bool maxRay = Physics.Raycast(boxCollider.bounds.max, Vector3.down, boxCollider.bounds.extents.y + extraHeight, groundLayer);

        isGrounded = centerRay || minRay || maxRay;

        if (!isGrounded)
        {
            animator.Play("Player_jump");
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = new Vector3(speed, rb.linearVelocity.y, rb.linearVelocity.z); //liikutaan oikealle

            if(isGrounded)
            {
                animator.Play("Player_run");
            }
            spriteRenderer.flipX = false; //käännetään pelaaja
        }

        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = new Vector3(-speed, rb.linearVelocity.y, rb.linearVelocity.z); //liikutaan vasemmalle

            if(isGrounded)
            {
                animator.Play("Player_run");
            }
            spriteRenderer.flipX = true; //käännetään pelaaja
        }

        else
        {
            if (isGrounded)
            {
                animator.Play("Player_idle");
            }
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, rb.linearVelocity.z); //pysähdys
            
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpVelocity, rb.linearVelocity.z); //liikutaan hypätään
        }

        if (rb.linearVelocity.y > 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

    }

}
