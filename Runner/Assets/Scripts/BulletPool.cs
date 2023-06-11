using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletPool
{
    public List<GameObject> Bullets { get; private set; }
    private BulletFactory _factory;

    [Inject]
    public BulletPool([Inject(Id = MyConstants.BULLET_AMOUNT)] int amountOfBullets, 
        BulletFactory factory)
    {
        Bullets = new List<GameObject>();
        _factory = factory;
        InitPool(amountOfBullets);
    }

    private void InitPool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            Bullet obj = _factory.Create();
            Bullets.Add(obj.gameObject);
        }
    }

    public GameObject Get(int index) => Bullets[index];

    public GameObject GetLast() => Bullets[Bullets.Count - 1];

    public void Return(GameObject item) => Bullets.Add(item);

    public void Add() => Bullets.Add(_factory.Create().gameObject);

    public class BulletFactory : PlaceholderFactory<Bullet>
    {

    }
}
