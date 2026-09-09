using UnityEngine;

[RequireComponent(typeof(Board))]
public class Level : MonoBehaviour
{
    [SerializeField] private LevelData _data;

    private Board _board;

    private void Awake()
    {
        _board = GetComponent<Board>();
    }

    private void Start()
    {
        _board.Initialize(_data.Biomes);
    }
}