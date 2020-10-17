﻿using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Inventory))]
[CustomPropertyDrawer(typeof(ItemProperties))]
public class EquipmentDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var rarityRect = new Rect(position.x, position.y, 90, position.height);
       // var equipSlRect = new Rect(position.x + 60, position.y, 60, position.height);
        //var defRect = new Rect(position.x + 120, position.y, 60, position.height);
        //var atkRect = new Rect(position.x + 180, position.y, 60, position.height);
       // var goldRect = new Rect(position.x + 240, position.y, 60, position.height);
        //var curSlRect = new Rect(position.x + 300, position.y, 60, position.height);
        //var nameRect = new Rect(position.x + 360, position.y, position.width - 90, position.height);

        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(rarityRect, property.FindPropertyRelative("rarity"), new GUIContent("Item Rarity"));
        //EditorGUI.PropertyField(equipSlRect, property.FindPropertyRelative("equippableSlot"), new GUIContent("Equippable Slot"));
        //EditorGUI.PropertyField(defRect, property.FindPropertyRelative("defense"), new GUIContent("Defense"));
        //EditorGUI.PropertyField(atkRect, property.FindPropertyRelative("attack"), new GUIContent("Attack"));
        //EditorGUI.PropertyField(goldRect, property.FindPropertyRelative("goldValue"), new GUIContent("Item Value"));
        //EditorGUI.PropertyField(curSlRect, property.FindPropertyRelative("currentSlot"), new GUIContent("Currently Equipped Slot"));
        //EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), new GUIContent("Item Name"));

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}