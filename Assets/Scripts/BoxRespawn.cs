using UnityEngine;

public class BoxRespawn : MonoBehaviour
{
    [SerializeField] private Transform Box;
    [SerializeField] private Transform respawnPoint;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Terrain")
        {
            Box.transform.position = respawnPoint.transform.position;
        }
    }
}
