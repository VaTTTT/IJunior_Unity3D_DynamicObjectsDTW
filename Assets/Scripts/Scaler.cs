using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _scaleFactor;
    
    private void Update()
    {
        transform.localScale += Vector3.one * _scaleFactor * Time.deltaTime;
    }
}