using System.Collections;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int lifetime;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private Rigidbody rb;

    private int _obstacleLayerMask;
    private bool isCoroutineStarted;
    private Transform _targetTransform;

    private void Awake()
    {
        _obstacleLayerMask = (int)Mathf.Log(obstacleLayer.value, 2);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, speed * Time.deltaTime);
        if (gameObject.activeSelf || !isCoroutineStarted)
            StartCoroutine(StartLife());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _obstacleLayerMask)
        {
            gameObject.SetActive(false);
            StopCoroutine(StartLife());
        }
    }

    IEnumerator StartLife()
    {
        isCoroutineStarted = true;
        yield return new WaitForSeconds(lifetime);
        isCoroutineStarted = false;
        gameObject.SetActive(false);
    }

    [Inject]
    public void Construct([Inject(Id = MyConstants.TARGET_TRANSFORM)] Transform targetTransform)
    {
        _targetTransform = targetTransform;
    }
}
