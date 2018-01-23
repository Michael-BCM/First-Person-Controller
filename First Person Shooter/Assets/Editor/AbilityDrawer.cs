using UnityEngine;
using UnityEditor;
/*
[CustomPropertyDrawer(typeof(Ability))]
public class AbilityDrawer : PropertyDrawer
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="position"></param>
    /// <param name="property"></param>
    /// <param name="label"></param>
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;

        EditorGUI.indentLevel = 0;

        Rect canUseRect = new Rect(position.x, position.y, position.width, position.height);

        EditorGUI.PropertyField(canUseRect, property.FindPropertyRelative("_canUse"));

        Rect isInUseRect = new Rect(position.x, position.y + 20, position.width, position.height);

        EditorGUI.PropertyField(isInUseRect, property.FindPropertyRelative("_isInUse"));

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 100F;
    }
}
*/