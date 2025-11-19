using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private ScoreCounter _scoreCounter;

    private void Awake()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += UpdateView;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= UpdateView;
    }

    private void UpdateView(int score)
    {
        _scoreText.text = score.ToString();
    }
}
