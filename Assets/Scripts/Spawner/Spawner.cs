using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private BrickHolder _brickHolder;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Brick _brickTemplate;

    private float elapsedTime = 0;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= _spawnDelay)
        {
            BrickPlace brickPlace = _brickHolder.Places.FirstOrDefault(place => place.IsAvailible);

            if (brickPlace != default)
            {
                brickPlace.Take();
                var brick = Instantiate(_brickTemplate, _spawnPoint.position, _brickTemplate.transform.rotation);
                brick.Init(brickPlace);
                brick.GetComponent<Fly>().Init(brickPlace.transform.position, brickPlace.transform.rotation);
                _brickHolder.OnBrickAdded();
            }
            elapsedTime = 0;
        }
    }
}
