using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _brickPerSpawn;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private BrickContainer _brickContainer;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Brick _brickTemplate;

    private float elapsedTime = 0;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= _spawnDelay)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                BrickPlace brickPlace = _brickContainer.Places.FirstOrDefault(place => place.IsAvailible);

                if (brickPlace != default)
                {
                    var brick = Instantiate(_brickTemplate, _spawnPoints[i].position, _brickTemplate.transform.rotation);
                    brickPlace.Reserve(brick);
                    brick.GetComponent<Fly>().InitFlyRoute(brickPlace.transform.position, brickPlace.transform.rotation);
                    _brickContainer.AddBrick();
                }
            }

            elapsedTime = 0;
        }
    }
}
