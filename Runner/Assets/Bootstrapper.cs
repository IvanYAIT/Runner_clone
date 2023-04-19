using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private List<GameObject> levelParts;
    [SerializeField] private int amountOfStartLevelParts;
    [SerializeField] private GameObject startPoint;

    private LevelGenerator levelGenerator;
    private LevelPartPool levelPartPool;

    void Start()
    {
        levelPartPool = new LevelPartPool(levelParts);
        levelPartPool.InitPool(amountOfStartLevelParts);
        levelGenerator = new LevelGenerator(startPoint, amountOfStartLevelParts, levelPartPool);
    }
}
