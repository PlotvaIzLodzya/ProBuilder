using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrickAmountPresenter : MonoBehaviour
{
    [SerializeField] private BrickHolder _brickHolder;
    [SerializeField] private TMP_Text _brickStats;


    private void OnEnable()
    {
        _brickHolder.BrickAmountChanged += UpdateBrickStats;
    }

    private void OnDisable()
    {
        _brickHolder.BrickAmountChanged -= UpdateBrickStats;
    }

    private void UpdateBrickStats(int currentBricksAmount, int maxbrickAmount)
    {
        _brickStats.text = $"{currentBricksAmount}/{maxbrickAmount}";
    }

}
