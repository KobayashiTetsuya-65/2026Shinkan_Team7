using System.Collections.Generic;
using UnityEngine;

public class FuelObjectPool : MonoBehaviour
{
    [Header("-----éQè∆-----")]
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _defaultCount = 10;

    private Queue<GameObject> _pool = new();
    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = GameManager.Instance;
        for (int i = 0; i < _defaultCount; i++)
        {
            CreateObject();
        }
    }

    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(_prefab, transform);
        obj.SetActive(false);

        _pool.Enqueue(obj);

        return obj;
    }

    public GameObject GetObject()
    {
        if (_pool.Count == 0)
        {
            CreateObject();
        }

        GameObject obj = _pool.Dequeue();

        obj.SetActive(true);

        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);

        _pool.Enqueue(obj);
    }
}
