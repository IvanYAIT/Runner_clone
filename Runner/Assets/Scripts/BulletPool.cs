using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletPool
{
    public List<GameObject> Bullets { get; private set; }
    private GameObject _bulletPrefab;
    private BulletFactory _factory;
    private DiContainer _container;

    [Inject]
    public BulletPool([Inject(Id = MyConstants.BULLET_PREFAB)] GameObject bulletPrefab, 
        [Inject(Id = MyConstants.BULLET_AMOUNT)] int amountOfBullets,
        [Inject(Id = MyConstants.TARGET_TRANSFORM)]Transform targetTransform, 
        BulletFactory factory,
        DiContainer container)
    {
        _bulletPrefab = bulletPrefab;
        Bullets = new List<GameObject>();
        _factory = factory;
        _container = container;
        InitPool(amountOfBullets, targetTransform);
    }

    private void InitPool(int poolSize, Transform targetTransform)
    {
        for (int i = 0; i < poolSize; i++)
        {
            //GameObject obj = _container.InstantiatePrefab(_bulletPrefab);
            //Bullets.Add(obj);
            //Bullet currentbullet = obj.GetComponent<Bullet>();
            //currentbullet = _factory.Create(targetTransform);
        }
    }

    public GameObject Get(int index) => Bullets[index];

    public GameObject GetLast() => Bullets[Bullets.Count - 1];

    public void Return(GameObject item) => Bullets.Add(item);

    public void Add() => Bullets.Add(GameObject.Instantiate(_bulletPrefab));

    public class BulletFactory : PlaceholderFactory<Transform, Bullet>
    {

    }
}
