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
        //InitLevel();
    }

    private void InitLevel()
    {
        int rndNum;
        for (int i = 0; i < _amountOfStartLevelParts; i++)
        {
            rndNum = Random.Range(0, _pool.LevelParts.Count);
            if (_pool.Get(rndNum).activeSelf)
            {
                i--;
            }
            else
            {
                _pool.Get(rndNum).SetActive(true);
                _pool.Get(rndNum).transform.position = _startPoint.transform.position;
                
                _startPoint.transform.position += new Vector3(0, 0,MOVE_DISTANCE);
            }
            
        }
    }

    public void Generate()
    {

    }
}
