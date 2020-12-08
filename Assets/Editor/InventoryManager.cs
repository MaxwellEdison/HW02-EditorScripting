using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



[CustomPropertyDrawer(typeof(Inventory)), CanEditMultipleObjects]

public class InventoryManager : PropertyDrawer
{
    public ItemProperties[] options;
    public int index = 0;
    public ItemManager _itemManager;
    public List<string> _options;

    //public string[] _options = { "hi", "hello", "how are you" };
    //[MenuItem("Examples/Editor GUILayout Popup usage")]
    /*    static void Init()
        {
            EditorWindow window = GetWindow(typeof(InventoryManager));
            window.Show();
        }*/

/*    string[] _choices = new[] { "foo", "foobar" };
    int _choiceIndex = 0;*/

    /*    public override void OnInspectorGUI()
        {
            // Draw the default inspector
            DrawDefaultInspector();
            _itemManager.itemDefinition[_choiceIndex].name = _choices[_choiceIndex];
            _choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices);
            // Update the selected choice in the underlying object

            // Save the changes back to the object
            EditorUtility.SetDirty(target);
        }*/

/*    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();
        GetList();

        index = EditorGUILayout.Popup(index, _options.ToArray());


        EditorUtility.SetDirty(target);

*//*        if (GUILayout.Button("Set Item"))
        {
            EquipItem();
        }*//*

    }*/
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
