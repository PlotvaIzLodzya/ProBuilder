using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrickAmountPresenter : MonoBehaviour
{
    [SerializeField] private BrickContainer _brickContainer;
    [SerializeField] private TMP_Text _brickStats;


    private void OnEnable()
    {
        _brickContainer.BrickAmountChanged += UpdateBrickStats;
    }

    private void OnDisable()
    {
        _brickContainer.BrickAmountChanged -= UpdateBrickStats;
    }

    private void UpdateBrickStats(int currentBricksAmount, int maxbrickAmount)
    {
        _brickStats.text = $"{currentBricksAmount}/{maxbrickAmount}";
    }

}
