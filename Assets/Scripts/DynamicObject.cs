using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DynamicObject : MonoBehaviour
{
    [SerializeField] private bool _isMovingForward;
    [SerializeField] private bool _isRotatingClockwise;
    [SerializeField] private bool _isIncreasingSize;

    [SerializeField][HideInInspector] private float _movingSpeed;
    [SerializeField][HideInInspector] private float _rotationSpeed;
    [SerializeField][HideInInspector] private float _increasingSizeSpeed;

    private void Update()
    {
        if (_isMovingForward)
        {
            MoveForward();
        }

        if (_isRotatingClockwise)
        {
            RotateClockwise();
        }

        if (_isIncreasingSize)
        {
            IncreaseSize();
        }
    }

    private void MoveForward()
    {
        this.transform.position += transform.forward * _movingSpeed * Time.deltaTime;
    }
    private void RotateClockwise()
    {
        float angleStep = 10;

        this.transform.Rotate(new Vector3(0, angleStep, 0) * _rotationSpeed * Time.deltaTime); 
    }

    private void IncreaseSize()
    {
        Vector3 sizeStep = new Vector3(0.1f, 0.1f, 0.1f);

        this.transform.localScale += sizeStep * _increasingSizeSpeed * Time.deltaTime;
    }
}

[CustomEditor(typeof(DynamicObject))]
[CanEditMultipleObjects]
public class DynamicObjectEditor : Editor
{
    SerializedProperty isMovingForwardProperty;
    SerializedProperty isRotatingClockwiseProperty;
    SerializedProperty isIncreasingSizeProperty;

    SerializedProperty movingSpeedProperty;
    SerializedProperty rotationSpeedProperty;
    SerializedProperty increasingSizeSpeedProperty;

    void OnEnable()
    {
        isMovingForwardProperty = serializedObject.FindProperty("_isMovingForward");
        isRotatingClockwiseProperty = serializedObject.FindProperty("_isRotatingClockwise");
        isIncreasingSizeProperty = serializedObject.FindProperty("_isIncreasingSize");
        movingSpeedProperty = serializedObject.FindProperty("_movingSpeed");
        rotationSpeedProperty = serializedObject.FindProperty("_rotationSpeed");
        increasingSizeSpeedProperty = serializedObject.FindProperty("_increasingSizeSpeed");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        isMovingForwardProperty.boolValue = EditorGUILayout.Toggle(label: "Moving Forward", isMovingForwardProperty.boolValue);
        
        if (isMovingForwardProperty.boolValue)
        {
            movingSpeedProperty.floatValue = EditorGUILayout.FloatField(label: "Moving Speed", movingSpeedProperty.floatValue);
        }

        isRotatingClockwiseProperty.boolValue = EditorGUILayout.Toggle(label: "Rotating Clockwise", isRotatingClockwiseProperty.boolValue);

        if (isRotatingClockwiseProperty.boolValue)
        {
            rotationSpeedProperty.floatValue = EditorGUILayout.FloatField(label: "Rotation Speed", rotationSpeedProperty.floatValue);
        }

        isIncreasingSizeProperty.boolValue = EditorGUILayout.Toggle(label: "Increasing Size", isIncreasingSizeProperty.boolValue);

        if (isIncreasingSizeProperty.boolValue)
        {
            increasingSizeSpeedProperty.floatValue = EditorGUILayout.FloatField(label: "Growth Speed", increasingSizeSpeedProperty.floatValue);
        }

        serializedObject.ApplyModifiedProperties();
    }
}