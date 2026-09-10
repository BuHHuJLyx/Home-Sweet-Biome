using UnityEngine;

public class MovementPath : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    public Transform[] Points => _points;
}