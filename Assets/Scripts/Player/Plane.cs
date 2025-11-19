using UnityEngine;
using System;

[RequireComponent(typeof(PlaneMuvier))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(PlaneCollisionHandler))]
public class Plane : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletPool;
    private PlaneMuvier _planeMuvier;
    private ScoreCounter _scoreCounter;
    private PlaneCollisionHandler _handler;

    public event Action GameOver;
    
    private void Awake()
    {
        _planeMuvier = GetComponent<PlaneMuvier>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<PlaneCollisionHandler>();
    }
    
    void Start()
    {
        GetComponent<Shoot>().SetBulletPool(_bulletPool);
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }
    
    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }
    
    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy)
        {
            GameOver?.Invoke();
        }
        
        else if (interactable is ScoreZone)
        {
            _scoreCounter.Add();
        }
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _planeMuvier.Reset();
    }
    
    public void Kill()
    {
        GameOver?.Invoke();
    }
}
