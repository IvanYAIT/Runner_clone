using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelPartData", menuName = "SO/NewLevelPartData")]
public class LevelPartData : ScriptableObject
{
    [SerializeField] private int index;
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<AvailableLevelPart> availableLevelParts;

    public int Index => index;
    public GameObject Prefab => prefab;
    public List<AvailableLevelPart> AvailableLevelParts => availableLevelParts;
}

[Serializable]
public class AvailableLevelPart
{
    [SerializeField] private LevelPartData levelPartData;
    [SerializeField] private int chance;

    public LevelPartData LevelPartData => levelPartData;
    public int Chance => chance;
}