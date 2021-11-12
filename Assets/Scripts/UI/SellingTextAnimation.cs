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

    private TMP_Text tmp_text;
    public int _value { get; private set; }

    private void Start()
    {
        tmp_text = GetComponent<TMP_Text>();
        tmp_text.text = $"+${_value}";
        tmp_text.DOFade(0f, _fadeTime).OnComplete(() => {
            Destroy(gameObject);
        });

        transform.DOMove(transform.position + Vector3.up *_animSpeed, _animTime);
    }

    public void SetText(int value)
    {
        _value = value;
    }
}
