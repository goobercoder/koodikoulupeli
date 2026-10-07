using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 2f;
    public bool movingRight = true;
    public Transform groundCheck;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); //liikkuminen

        if (!Physics.Raycast(groundCheck.position, Vector3.down, distance))
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0); //hahmo käännetään vasemmalle
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0); //hahmo käännetään oikealle
                movingRight = true;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
