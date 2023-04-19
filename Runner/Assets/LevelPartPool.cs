using System.Collections.Generic;
using UnityEngine;

public class LevelPartPool
{
    public List<GameObject> LevelParts { get; private set; }

    private List<GameObject> _levelPartPrefabs;

    public LevelPartPool(List<GameObject> levelparts)
    {
        _levelPartPrefabs = levelparts;
        LevelParts = new List<GameObject>();
    }

    public void InitPool(int poolSize)
    {
        for (int i = 0; i < _levelPartPrefabs.Count; i++)
        {
            GameObject obj = Object.Instantiate(_levelPartPrefabs[i]);
            LevelParts.Add(obj);
        }

        if (poolSize > LevelParts.Count)
            for (int i = 0; i < poolSize - LevelParts.Count+2; i++)
            {
                Add();
            }
    }

    public GameObject Get(int index) => LevelParts[index];

    public void Return(GameObject item) => LevelParts.Add(item);

    public void Add()
    {
        GameObject obj = Object.Instantiate(_levelPartPrefabs[Random.Range(0, _levelPartPrefabs.Count)]);
        LevelParts.Add(obj);
    }
}