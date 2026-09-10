using System;
using UnityEngine;

public class AnimalMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    
    private MovementPath _path;
    private int _currentPoint;
    private bool _isMoving;

    public void Initialize(MovementPath path)
    {
        _path = path;
        _currentPoint = 0;
    }

    private void Update()
    {
        if (_isMoving ==  false)
            return;
        
        Move();
    }

    public void StartMoving()
    {
        if (_path == null || _path.Points.Length == 0)
            return;
        
        _isMoving = true;
    }

    public void Move()
    {
        if (_path == null || _currentPoint >= _path.Points.Length)
        {
            _isMoving = false;
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _path.Points[_currentPoint].position, _speed * Time.deltaTime);
        
        if (transform.position == _path.Points[_currentPoint].position)
            _currentPoint++;
    }
}