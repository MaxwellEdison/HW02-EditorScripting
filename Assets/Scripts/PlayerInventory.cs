using System;
using UnityEngine;
using System.Collections.Generic;





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
