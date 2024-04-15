using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _duration = 1f;

    private void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), _duration / _speed, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }
}