using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Gm").GetComponent<GameMaster>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gm.checkPointPos = transform.position;
        }
    }

    
}
