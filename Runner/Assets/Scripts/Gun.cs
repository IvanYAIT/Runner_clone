using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Gun : MonoBehaviour
{
    private Transform _firePoint;
    private BulletPool _pool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    [Inject]
    public void Construct(Transform firePoint, BulletPool pool)
    {
        _firePoint = firePoint;
        _pool = pool;
    }

    private void Shoot()
    {
        for (int i = 0; i < _pool.Bullets.Count; i++)
        {
            if (!_pool.Bullets[i].activeSelf)
            {
                _pool.Bullets[i].transform.position = _firePoint.position;
                _pool.Bullets[i].SetActive(true);
                break;
            }
        }
    }
}
