using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private bool smartGenerator;

    private LevelGenerator _levelGenerator;
    private SmartLevelGenerator _smartLevelGenerator;


    private void Update()
    {
        if (!smartGenerator)
            _levelGenerator.Generate();
        else
            _smartLevelGenerator.Generate();
    }

    [Inject]
    public void Construct(LevelGenerator levelGenerator, SmartLevelGenerator smartLevelGenerator)
    {
        _levelGenerator = levelGenerator;
        _smartLevelGenerator = smartLevelGenerator;
    }
}
