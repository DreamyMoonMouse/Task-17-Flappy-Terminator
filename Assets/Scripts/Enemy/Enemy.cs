using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour, IInteractable, IDamageable, IPoolable<Enemy>
{
    [SerializeField] private float _lifeTime = 5f;
    
    private float _timer;
    
    public event Action<Enemy> Deactivated;
    
    private void OnEnable()
    {
        _timer = 0f;
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= _lifeTime)
            Die();
    }
    
    public void Die()
    {
        Deactivated?.Invoke(this);
    }
}