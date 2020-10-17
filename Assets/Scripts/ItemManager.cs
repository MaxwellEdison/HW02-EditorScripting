using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Legendary
}

public enum EquipSlot
{
    Head,
    Torso,
    Arms,
    Legs,
    Feet
}

public enum CurSlot
{
    Head,
    Torso,
    Arms,
    Legs,
    Feet,
    Inventory
}

[Serializable]
public class ItemProperties
{
    public string name;
    public EquipSlot equippableSlot;
    public int attack;
    public int defense;
    public Rarity rarity;
    public int goldValue;
    public CurSlot currentSlot;
}
public class ItemManager : MonoBehaviour
{
    public ItemProperties[] itemDefinition;
}
