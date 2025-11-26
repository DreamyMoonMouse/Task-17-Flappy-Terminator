using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Component
{
    [SerializeField] protected ObjectPool<T> _pool;
    [SerializeField] protected float _spawnRate = 1f;

    private float _timer;

    protected void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnRate)
        {
            Spawn();
            _timer = 0f;
        }
    }
    
    protected abstract void Spawn();
}