using UnityEngine;

public class LevelGenerator
{
    private const float MOVE_DISTANCE = 15;
    private GameObject _startPoint;
    private int _amountOfStartLevelParts;
    private LevelPartPool _pool;

    public LevelGenerator(GameObject startPoint, int amountOfStartLevelParts, LevelPartPool pool)
    {
        _startPoint = startPoint;
        _amountOfStartLevelParts = amountOfStartLevelParts;
        _pool = pool;
        InitLevel();
    }

    public void Generate()
    {
        foreach (LevelPart item in _pool.LevelParts)
        {
            if (!item.gameObject.activeSelf)
            {
                CreateLevelPart(item);
                break;
            }
        }
    }

    private void InitLevel()
    {
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
                CreateLevelPart(_pool.Get(rndNum));
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
