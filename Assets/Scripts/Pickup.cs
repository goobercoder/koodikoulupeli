using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        PLayerManager manager = collision.GetComponent<PlayerManager>();
        //jatka
    }
}
