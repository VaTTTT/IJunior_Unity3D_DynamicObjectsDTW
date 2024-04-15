using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;

    private float _duration = 1f;

    private void Start()
    {
        transform.DOMove(transform.localPosition + transform.forward * _distance, _duration / _speed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}