using System;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private List<LevelPartData> levelPartsDatas;
    [SerializeField] private int amountOfStartLevelParts;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private bool smartGenerator;

    private LevelGenerator levelGenerator;
    private SmartLevelGenerator smartLevelGenerator;
    private LevelPartPool levelPartPool;
    private ServiceLocator serviceLocator;

    void Start()
    {
        levelPartPool = new LevelPartPool(levelPartsDatas);
        levelPartPool.InitPool(amountOfStartLevelParts);

        Dictionary<Type, IGameService> services = new Dictionary<Type, IGameService>()
        {
            {typeof(RandomizeService), new RandomizeService(levelPartPool) }
        };
        serviceLocator = new ServiceLocator(services);

        if (!smartGenerator)
            levelGenerator = new LevelGenerator(startPoint, amountOfStartLevelParts, levelPartPool);
        else
            smartLevelGenerator = new SmartLevelGenerator(startPoint, amountOfStartLevelParts, levelPartPool, levelPartsDatas, serviceLocator);
    }

    private void Update()
    {
        if (!smartGenerator)
            levelGenerator.Generate();
        //else
        //    smartLevelGenerator.Generate();
    }
}
