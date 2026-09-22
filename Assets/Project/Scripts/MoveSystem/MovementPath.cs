using UnityEngine;

public class MovementPath : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    public Transform[] Points => _points;

    public int GetClosestPointIndex(Vector3 position)
    {
        int pointIndex = 0;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < _points.Length; i++)
        {
            float distance = Vector3.Distance(position, _points[i].position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                pointIndex = i;
            }
        }

        return pointIndex;
    }
}