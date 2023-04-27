using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int lifetime;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private Rigidbody rb;

    private int _obstacleLayerMask;
    private bool isCoroutineStarted;

    private void Awake()
    {
        _obstacleLayerMask = (int)Mathf.Log(obstacleLayer.value, 2);
    }

    private void Update()
    {
        rb.AddForce(new Vector3(0, 0, speed));
        if (gameObject.activeSelf || !isCoroutineStarted)
            StartCoroutine(StartLife());
    }

    IEnumerator StartLife()
    {
        isCoroutineStarted = true;
        yield return new WaitForSeconds(lifetime);
        isCoroutineStarted = false;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _obstacleLayerMask)
        {
            gameObject.SetActive(false);
            StopCoroutine(StartLife());
        }
    }
}
