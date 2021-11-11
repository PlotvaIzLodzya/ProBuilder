using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class SellingTextAnimation : MonoBehaviour
{
    [SerializeField] private TMP_Text _selling;

    public int _value { get; private set; }

    private void Start()
    {
        TMP_Text tmp_text = GetComponent<TMP_Text>();
        tmp_text.text = $"{_value}";
        tmp_text.DOFade(0f, 0.5f);

        transform.DOMove(transform.position + Vector3.up, 0.75f).OnComplete(() => {
            Destroy(gameObject);
        });
    }

    public void SetText(int value)
    {
        _value = value;
    }
}
