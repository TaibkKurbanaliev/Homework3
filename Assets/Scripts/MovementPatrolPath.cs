using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPatrolPath : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;
    
    private void Update()
    {
        if (transform.position == _endPoint.position)
        {
            var temp = _endPoint;
            _endPoint = _startPoint;
            _startPoint = temp;
        }

        transform.position = Vector3.MoveTowards(transform.position, _endPoint.position, _speed * Time.deltaTime);
    }
}
