using System;
using UnityEngine;





[Serializable]
public class Inventory
{
    public int _numberOfItems;
}

public class PlayerInventory : MonoBehaviour
{
    public Inventory currentlyEquipped;

    //public Inventory[] playerInventory;
    
}
