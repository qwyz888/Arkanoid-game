using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private int _amountToPool;
    
    private readonly List<GameObject> _objects = new();
    private void OnEnable()
    {
        CreatePool();

    }

    private void CreatePool()
    {
        _objects.Clear();
        GameObject temp;
        for (int i = 0; i < _amountToPool; i++)
        {
            temp = Instantiate(_object,transform);
            temp.SetActive(false);
            _objects.Add(temp);
        }
    }

   public GameObject GetObject()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            if (!_objects[i].activeInHierarchy)
            {
                return _objects[i];
            }

        }
        return null;
    }
}
