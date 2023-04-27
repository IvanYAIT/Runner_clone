using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletPool
{
    public List<GameObject> Bullets { get; private set; }
    private GameObject _bulletPrefab;

    [Inject]
    public BulletPool([Inject(Id = MyConstants.BULLET_PREFAB)] GameObject bulletPrefab, [Inject(Id = MyConstants.BULLET_AMOUNT)] int amountOfBullets)
    {
        _bulletPrefab = bulletPrefab;
        Bullets = new List<GameObject>();
        InitPool(amountOfBullets);
    }

    private void InitPool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            Bullets.Add(GameObject.Instantiate(_bulletPrefab));
        }
    }

    public GameObject Get(int index) => Bullets[index];

    public GameObject GetLast() => Bullets[Bullets.Count - 1];

    public void Return(GameObject item) => Bullets.Add(item);

    public void Add() => Bullets.Add(GameObject.Instantiate(_bulletPrefab));
}
