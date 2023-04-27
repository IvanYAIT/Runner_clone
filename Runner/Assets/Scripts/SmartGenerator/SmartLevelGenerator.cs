using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SmartLevelGenerator
{
    private const float MOVE_DISTANCE = 15;
    private GameObject _startPoint;
    private int _amountOfStartLevelParts;
    private LevelPartPool _pool;
    private List<LevelPartData> _levelPartsDatas;
    private RandomizeService _rndService;

    [Inject]
    public SmartLevelGenerator([Inject(Id = MyConstants.LEVEL_START_POINT)]GameObject startPoint, [Inject(Id = MyConstants.LEVEL_PART_POOL_SIZE)] int amountOfStartLevelParts, LevelPartPool pool, List<LevelPartData> levelPartsDatas, RandomizeService rndService)
    {
        _startPoint = startPoint;
        _amountOfStartLevelParts = amountOfStartLevelParts;
        _pool = pool;
        _levelPartsDatas = levelPartsDatas;
        _rndService = rndService;
        //InitLevel();
    }

    public void Generate()
    {

    }

    private void InitLevel()
    {
        LevelPart firstPart = _pool.Get(Random.Range(0, _pool.LevelParts.Count));
        CreateLevelPart(firstPart);

        int rndNum;
        for (int i = 0; i < _amountOfStartLevelParts; i++)
        {
            rndNum = Random.Range(0, _pool.LevelParts.Count);
            if (_pool.Get(rndNum).gameObject.activeSelf)
            {
                i--;
            }
            else
            {
                CreateLevelPart(_pool.Get(_rndService.Randomize(firstPart.Index, _levelPartsDatas)));
            }
        }
    }


    private void CreateLevelPart(LevelPart item)
    {
        item.gameObject.SetActive(true);
        item.transform.position = _startPoint.transform.position;

        _startPoint.transform.position += new Vector3(0, 0, MOVE_DISTANCE);
    }
}
