using UnityEngine;

public class FireballBullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 1.0f;

    Rigidbody rb;


    public void StartShoot(bool isFacingLeft)
    {
        rb = GetComponent<Rigidbody>();


        if (isFacingLeft)
        {
            rb.linearVelocity = new Vector3(-speed, 0, 0);
        }
        else
        {
            rb.linearVelocity = new Vector3(speed, 0, 0);
        }

        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(!collision.CompareTag("Player"))
            Destroy(gameObject);
    }
}