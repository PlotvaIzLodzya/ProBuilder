using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class SellingTextAnimation : MonoBehaviour
{
    [SerializeField] private float _fadeTime;
    [SerializeField] private float _animTime;
    [SerializeField] private float _animSpeed;

    private TMP_Text _tmpText;
    public int _value { get; private set; }

    private void Start()
    {
        _tmpText = GetComponent<TMP_Text>();
        _tmpText.text = $"+${_value}";
        _tmpText.DOFade(0f, _fadeTime).OnComplete(() => {
            Destroy(gameObject);
        });

        transform.DOMove(transform.position + Vector3.up *_animSpeed, _animTime);
    }

    public void SetText(int value)
    {
        _value = value;
    }
}
