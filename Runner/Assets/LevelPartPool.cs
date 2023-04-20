using System.Collections.Generic;
using UnityEngine;

public class LevelPartPool
{
    public List<LevelPart> LevelParts { get; private set; }

    private List<LevelPartData> _levelPartsDatas;

    public LevelPartPool(List<LevelPartData> levelpartsDatas)
    {
        _levelPartsDatas = levelpartsDatas;
        LevelParts = new List<LevelPart>();
    }

    public void InitPool(int poolSize)
    {
        if(poolSize < _levelPartsDatas.Count)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Object.Instantiate(_levelPartsDatas[i].Prefab);
                LevelPart objLevelPart = obj.GetComponent<LevelPart>();
                objLevelPart.SetIndex(_levelPartsDatas[i].Index);
                LevelParts.Add(objLevelPart);
            }
        }
        else
        {
            for (int i = 0; i < _levelPartsDatas.Count; i++)
            {
                GameObject obj = Object.Instantiate(_levelPartsDatas[i].Prefab);
                LevelPart objLevelPart = obj.GetComponent<LevelPart>();
                objLevelPart.SetIndex(_levelPartsDatas[i].Index);
                LevelParts.Add(objLevelPart);
            }
            if (poolSize > LevelParts.Count)
                for (int i = 0; i < poolSize - _levelPartsDatas.Count; i++)
                {
                    Add();
                }
        }
    }

    public LevelPart Get(int index) => LevelParts[index];

    public LevelPart GetLast() => LevelParts[LevelParts.Count - 1];

    public void Return(LevelPart item) => LevelParts.Add(item);

    public void Add()
    {
        int rndNum = Random.Range(0, _levelPartsDatas.Count);
        GameObject obj = Object.Instantiate(_levelPartsDatas[rndNum].Prefab);
        LevelPart objLevelPart = obj.GetComponent<LevelPart>();
        objLevelPart.SetIndex(_levelPartsDatas[rndNum].Index);
        LevelParts.Add(objLevelPart);
        LevelParts.Add(obj.GetComponent<LevelPart>());
    }
}