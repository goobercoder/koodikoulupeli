using UnityEngine;

public class BoxRespawn : MonoBehaviour
{
    [SerializeField] private Transform Box;
    [SerializeField] private Transform respawnPoint;
    private Button button;
    
    void Start()
    {
        button = GameObject.FindGameObjectWithTag("Button").GetComponent<Button>();
    }
    

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Terrain")
        {
            Box.transform.position = respawnPoint.transform.position;
            button.OnRespawn();
        }
    }
}
