using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Brick _brickTemplate;


    public void CreateBrick()
    {
        var brick = Instantiate(_brickTemplate, _spawnPoint.position, _brickTemplate.transform.rotation);
    }
}
