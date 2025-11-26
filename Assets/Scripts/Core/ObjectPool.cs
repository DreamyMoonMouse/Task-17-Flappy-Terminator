using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _initialSize = 10;

    private Queue<GameObject> _pool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < _initialSize; i++)
        {
            var obj = CreateNew();
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public GameObject Get(Vector3 position, Quaternion rotation)
    {
        GameObject obj;
        
        if (_pool.Count > 0 && !_pool.Peek().activeSelf)
        {
            obj = _pool.Dequeue();
        }
        else
        {
            obj = CreateNew();
        }

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
        _pool.Enqueue(obj);
        return obj;
    }
    
    private GameObject CreateNew()
    {
        var obj = Instantiate(_prefab, transform);
        return obj;
    }
}

