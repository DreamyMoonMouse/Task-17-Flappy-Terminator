using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void Awake()
    {
        Hide();
    }

    public void Show()
    {
        _panel.SetActive(true);
    }

    private void Hide()
    {
        _panel.SetActive(false);
    }
}