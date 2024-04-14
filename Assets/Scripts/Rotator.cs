using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _angleStep;

    private void Update()
    {
        transform.Rotate(Vector3.up, _angleStep * Time.deltaTime);
    }
}