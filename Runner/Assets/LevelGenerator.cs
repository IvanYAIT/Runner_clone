using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private LevelPartPool _pool;

    private void Start()
    {
        for (int i = 0; i < _pool.LevelParts.Count; i++)
        {

        }
    }

    void Update()
    {
        
    }

    public void Construct(LevelPartPool levelPartPool)
    {
        _pool = levelPartPool;
    }
}
