using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _generalPoint;
    [SerializeField] private Coin _coin;

    private Transform[] _points;
    private int _delay = 2;

    private void Start()
    {
        _points = new Transform[_generalPoint.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _generalPoint.GetChild(i).transform;
        }

        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        var waiter = new WaitForSeconds(_delay);

        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_coin, _points[i].position, _points[i].rotation);
            yield return waiter;
        }
    }
}
