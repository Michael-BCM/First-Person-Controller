using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Recipe.Ingredient))]
public class IngredientDrawer : PropertyDrawer
{
    /// <summary>
    /// Draws the property inside the given rectangle.
    /// </summary>
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ///Begins the property, using the same three parameters defined in the method OnGUI.
        EditorGUI.BeginProperty(position, label, property);

        ///Draws the title label. 
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        ///Backs up the default indent level to a variable. 
        var indent = EditorGUI.indentLevel;

        ///Sets the indent level to 0. 
        EditorGUI.indentLevel = 0;

        ///Creates a new rectangle for the 'amount' field. 
        var amountRect = new Rect(position.x, position.y, 30, position.height);

        ///Creates a new rectangle for the 'unit' field. 
        var unitRect = new Rect(position.x + 35, position.y, 50, position.height);

        ///Creates a new rectangle for the 'name' field. 
        var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);
        
        ///Creates a new field for a property, to be determined. 
        ///The field is of the size determined by the rectangle 'amountRect', the property becomes 'amount', and the field has no label. 
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("amount"), GUIContent.none);

        ///Creates a new field for a property, to be determined. 
        ///The field is of the size determined by the rectangle 'unitRect', the property becomes 'unit', and the field has no label. 
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("unit"), GUIContent.none);

        ///Creates a new field for a property, to be determined. 
        ///The field is of the size determined by the rectangle 'nameRect', the property becomes 'name', and the field has no label. 
        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);

        ///Restores the default indent level.
        EditorGUI.indentLevel = indent;

        ///Ends the property.
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }
}