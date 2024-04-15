using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _scale;
    [SerializeField] private float _speed;

    private float _time = 1f;
    
    private void Start()
    {
        transform.DOScale(_scale, _time / _speed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}