using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private List<GameObject> levelParts;
    [SerializeField] private LevelGenerator levelGenerator;

    private LevelPartPool levelPartPool;

    void Start()
    {
        levelPartPool = new LevelPartPool(levelParts);
        levelGenerator.Construct(levelPartPool);
    }
}
