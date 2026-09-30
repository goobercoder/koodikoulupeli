using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<string> inventory;
    public int coinCount;

    void Start()
    {
        inventory = new List<string>();
    }
    public void PickupItem()
    {
        coinCount += 1;
    }
}