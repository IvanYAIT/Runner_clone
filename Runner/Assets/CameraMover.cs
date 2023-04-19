using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private const float SPEED = 15;

    void Update()
    {
        transform.position += new Vector3(0, 0, SPEED * Time.deltaTime);
    }
}