using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RandomizeService : IRandomizeService
{
    private LevelPartPool _pool;

    [Inject]
    public RandomizeService(LevelPartPool pool)
    {
        _pool = pool;
    }

    public int Randomize(int index, List<LevelPartData> levelPartDatas)
    {
        List<AvailableLevelPart> availableLevelParts = GetActiveData(index, levelPartDatas).AvailableLevelParts;
        List<int> nonActiveLevelPartIndexes = new List<int>();

        
        
        for (int i = 0; i < _pool.LevelParts.Count; i++)
        {
            if (!_pool.LevelParts[i].gameObject.activeSelf)
            {
                foreach (AvailableLevelPart item in availableLevelParts)
                {
                    if (item.LevelPartData.Index == _pool.LevelParts[i].Index)
                        nonActiveLevelPartIndexes.Add(i);
                }
            }
        }
        if(nonActiveLevelPartIndexes.Count != 0)
            return nonActiveLevelPartIndexes[Random.Range(0, nonActiveLevelPartIndexes.Count)];
        else
        {
            for (int i = 0; i < _pool.LevelParts.Count; i++)
            {
                if (!_pool.LevelParts[i].gameObject.activeSelf)
                    return i;
            }
        }
        throw new System.Exception("NO ACTIVE LEVEL PARTS");
    }

    private LevelPartData GetActiveData(int index, List<LevelPartData> levelPartDatas)
    {
        foreach (LevelPartData item in levelPartDatas)
        {
            if (item.Index == index)
                return item;
        }
        throw new System.Exception("NO DATA");
    }
}
