using System.Collections.Generic;
using UnityEngine;

public class LevelPartPool
{
    public List<GameObject> LevelParts { get; private set; }

    public LevelPartPool(List<GameObject> levelparts)
    {
        LevelParts = levelparts;
    }
}