using UnityEngine;

public class AnimalMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private MovementPath _path;

    private Vector3 _exitPosition;
    private Vector3 _entrancePosition;
    private Vector3 _targetPosition;

    private int _currentPoint;
    private int _entrancePoint;

    private bool _isMoving;
    private MoveStage _moveStage;
    
    public bool IsMoving => _isMoving;

    private void Update()
    {
        if (_isMoving == false)
            return;

        Move();
    }

    public void Initialize(MovementPath path)
    {
        _path = path;
    }

    public void StartMoving(Vector3 startPosition, Vector3 exitPosition, Vector3 entrancePosition, Vector3 targetPosition)
    {
        if (_path == null || _path.Points.Length == 0)
            return;
        
        _exitPosition = exitPosition;
        _entrancePosition = entrancePosition;
        _targetPosition = targetPosition;
        
        _currentPoint = _path.GetClosestPointIndex(exitPosition);
        _entrancePoint = _path.GetClosestPointIndex(entrancePosition);
        
        _moveStage = MoveStage.ToExit;
        _isMoving = true;
    }

    private void Move()
    {
        Vector3 targetPosition = GetCurrentTarget();

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        if (transform.position != targetPosition)
            return;

        switch (_moveStage)
        {
            case MoveStage.ToExit:
                _moveStage = MoveStage.AlongPath;
                break;

            case MoveStage.AlongPath:
                if (_currentPoint == _entrancePoint)
                    _moveStage = MoveStage.ToTarget;
                else
                    _currentPoint = (_currentPoint + 1) % _path.Points.Length;
                break;

            case MoveStage.ToTarget:
                _isMoving = false;
                break;
        }
    }
    
    private Vector3 GetCurrentTarget()
    {
        switch (_moveStage)
        {
            case MoveStage.ToExit:
                return _exitPosition;

            case MoveStage.AlongPath:
                if (_currentPoint == _entrancePoint)
                    return _entrancePosition;

                return _path.Points[_currentPoint].position;

            case MoveStage.ToTarget:
                return _targetPosition;

            default:
                return transform.position;
        }
    }
}