using UnityEngine;
using System;

[RequireComponent(typeof(PlaneMuvier))]
[RequireComponent(typeof(PlaneCollisionHandler))]
public class Plane : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletPool;
    
    private PlaneMuvier _planeMover;
    private PlaneCollisionHandler _handler;

    public event Action GameOver;
    
    private void Awake()
    {
        _planeMover = GetComponent<PlaneMuvier>();
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
        if (interactable is Enemy || interactable is Ground)
            GameOver?.Invoke();
    }

    public void Reset()
    {
        _planeMover.Reset();
    }
    
    public void Kill()
    {
        GameOver?.Invoke();
    }
}
