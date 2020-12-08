using UnityEditor;
using UnityEngine;
using System.Collections.Generic;



[CustomPropertyDrawer(typeof(Inventory)), CanEditMultipleObjects]

public class InventoryManager : PropertyDrawer
{
    public ItemProperties[] options;
    public int index = 0;
    public ItemManager _itemManager;
    public List<string> _options;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        int numberOfItems = property.FindPropertyRelative("_numberOfItems").intValue;
        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        var numberRect = new Rect(position.x, position.y, 90, position.height);
        EditorGUI.PropertyField(numberRect, property.FindPropertyRelative("_numberOfItems"), GUIContent.none);
        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        //DrawDefaultInspector();
        GetList();
/*        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Increase Array Size"))
        {
            Debug.Log("We pressed 'Increase Array Size'");
            numberOfItems++;
        }
        if (GUILayout.Button("Decrease Array Size"))
        {
            Debug.Log("We pressed 'Decrease Array Size'");
            numberOfItems--;
        }
        GUILayout.EndHorizontal();*/
        for (int i = 1; i<numberOfItems+1; i++)
        {
            Rect _position = new Rect(position.x,position.y * (i+1), 90, position.height);
            EditorGUI.Popup(_position,index, _options.ToArray());
        }


    }

    void GetList()
    {

        _itemManager = GameObject.Find("InventoryObjectRepresentative").GetComponent<ItemManager>();
        _options = new List<string>();
        options = _itemManager.itemDefinition;
        for (int i = 0; i < _itemManager.itemDefinition.Length; i++)
        {
            _options.Add("(" + _itemManager.itemDefinition[i].equippableSlot.ToString() + ") " + _itemManager.itemDefinition[i].name);
        }

    }

}
