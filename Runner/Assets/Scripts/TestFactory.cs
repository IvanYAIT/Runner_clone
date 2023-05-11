using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestFactory : MonoBehaviour
{
    private BulletNonMono.NonMonoBulletFactory _factory;
    private Transform _target;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            BulletNonMono bullet = _factory.Create(_target);
            bullet.Name = "aaaaaa";
            Debug.Log(bullet.Name);
        }
      
    }

    [Inject]
    public void Construct(BulletNonMono.NonMonoBulletFactory factory, [Inject(Id = MyConstants.TARGET_TRANSFORM)]Transform target)
    {
        _factory = factory;
        _target = target;
    }
}
