using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : Component, IPoolable<T>
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _initialSize = 10;

    private Queue<T> _pool = new Queue<T>();

    private void Awake()
    {
        for (int i = 0; i < _initialSize; i++)
        {
            T obj = CreateAndSubscribe();
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public T Get(Vector3 position, Quaternion rotation)
    {
        T obj;
        
        if (_pool.Count > 0)
        {
            obj = _pool.Dequeue();
        }
        else
        {
            obj = CreateAndSubscribe();
        }

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.gameObject.SetActive(true);
        
        return obj;
    }

    private T CreateAndSubscribe()
    {
        T obj = Instantiate(_prefab, transform);
        obj.Deactivated += OnObjectDeactivated;
        return obj;
    }
    
    private void OnObjectDeactivated(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
    
    private void OnDestroy()
    {
        foreach (T obj in _pool)
        {
            if (obj != null)
                obj.Deactivated -= OnObjectDeactivated;
        }
    }
}


