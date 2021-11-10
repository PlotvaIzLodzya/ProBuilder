using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHolder : MonoBehaviour
{
    [SerializeField] private List<Transform> _places;
    [SerializeField] private Brick _brickTemplate;

    private int _index = 0;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _places.Add(transform.GetChild(i));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            FillUp();
    }

    private void FillUp()
    {
        for (int i = 0; i < _places.Count; i++)
        {
            
        }

        Instantiate(_brickTemplate, _places[_index++].position, _brickTemplate.transform.rotation);

    }
}
