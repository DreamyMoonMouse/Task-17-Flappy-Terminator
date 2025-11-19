using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    private int _score;

    public int Score => _score;

    public void Add()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
