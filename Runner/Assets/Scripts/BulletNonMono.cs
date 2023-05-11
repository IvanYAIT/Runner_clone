using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletNonMono
{
    private Transform _targetTransform;
    public string Name { get; set; }

    [Inject]
    public BulletNonMono(Transform targetTransform)
    {
        _targetTransform = targetTransform;
    }

    public class NonMonoBulletFactory : PlaceholderFactory<Transform, BulletNonMono>
    {

    }
}
