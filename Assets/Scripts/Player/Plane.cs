using UnityEngine;
using System;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlaneCollisionHandler))]
public class Plane : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletPool;
    
    private PlayerMover _planeMover;
    private PlaneCollisionHandler _handler;

    public event Action Died;
    
    private void Awake()
    {
        _planeMover = GetComponent<PlayerMover>();
        _handler = GetComponent<PlaneCollisionHandler>();
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

    public void Reset()
    {
        _planeMover.Reset();
    }
    
    public void Kill()
    {
        Died?.Invoke();
    }
    
    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy || interactable is Ground)
            Died?.Invoke();
    }
}
