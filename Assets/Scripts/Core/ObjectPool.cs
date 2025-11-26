using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _initialSize = 10;

    private Queue<T> _pool = new Queue<T>();

    private void Awake()
    {
        for (int i = 0; i < _initialSize; i++)
        {
            T obj = CreateNew();
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public T Get(Vector3 position, Quaternion rotation)
    {
        T obj;
        
        if (_pool.Count > 0 && !_pool.Peek().gameObject.activeSelf)
        {
            obj = _pool.Dequeue();
        }
        else
        {
            obj = CreateNew();
        }

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.gameObject.SetActive(true);
        _pool.Enqueue(obj);
        
        return obj;
    }

    public void Return(T obj)
    {
        if (obj != null)
        {
            obj.gameObject.SetActive(false);
        }
    }
    
    private T CreateNew()
    {
        T obj = Instantiate(_prefab, transform);
        return obj;
    }
}


