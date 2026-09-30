using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string itemType;
    private void OnTriggerEnter(Collider collision)
    {
        PlayerManager manager = collision.GetComponent<PlayerManager>();


        if (manager)
        {
            print("You collected a " + itemType);
            manager.inventory.Add(itemType);
            manager.PickupItem();
            Destroy(gameObject);
        }
    }
}