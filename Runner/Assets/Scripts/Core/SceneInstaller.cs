using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private int amountOfBullets;
    [SerializeField] private int amountOfStartLevelParts;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private List<LevelPartData> levelpartsDatas;
    [SerializeField] private GameObject levelStartPoint;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private TestFactory testFactory;

    public override void InstallBindings()
    {
        Container.Bind<int>().WithId(MyConstants.BULLET_AMOUNT).FromInstance(amountOfBullets).AsCached().NonLazy();
        Container.Bind<int>().WithId(MyConstants.LEVEL_PART_POOL_SIZE).FromInstance(amountOfStartLevelParts).AsCached().NonLazy();
        Container.Bind<GameObject>().WithId(MyConstants.BULLET_PREFAB).FromInstance(bulletPrefab).AsCached().NonLazy();
        Container.Bind<GameObject>().WithId(MyConstants.LEVEL_START_POINT).FromInstance(levelStartPoint).AsCached().NonLazy();

        Container.Bind<Transform>().WithId(MyConstants.TARGET_TRANSFORM).FromInstance(targetTransform).AsCached().NonLazy();

        Container.Bind<RandomizeService>().AsSingle().NonLazy();
        Container.Bind<Transform>().WithId(MyConstants.FIRE_POINT).FromInstance(firePoint).AsCached().NonLazy();
        Container.Bind<List<LevelPartData>>().FromInstance(levelpartsDatas).AsSingle().NonLazy();
        Container.Bind<LevelPartPool>().AsSingle().NonLazy();
        Container.Bind<BulletPool>().AsSingle().NonLazy();
        Container.Bind<LevelGenerator>().AsSingle().NonLazy();
        Container.Bind<SmartLevelGenerator>().AsSingle().NonLazy();
        Container.BindFactory<Transform, Bullet, BulletPool.BulletFactory>().AsSingle().NonLazy();

        Container.Bind<TestFactory>().FromInstance(testFactory).AsSingle().NonLazy();
        Container.BindFactory<Transform, BulletNonMono, BulletNonMono.NonMonoBulletFactory>().AsSingle().NonLazy();
    }
}