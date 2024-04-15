using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _textField1;
    [SerializeField] private string _text1;

    [SerializeField] private Text _textField2;
    [SerializeField] private string _text2;

    [SerializeField] private Text _textField3;
    [SerializeField] private string _text3;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;



    private void Start()
    {
        _textField1.DOText(_text1, _text1.Length / _speed);
        _textField2.DOText(_text2, _text1.Length / _speed).SetRelative().SetDelay(_delay);
        _textField3.DOText(_text3, _text1.Length / _speed, true, ScrambleMode.All).SetDelay(_delay += _delay);
    }
}
