using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private const float SPEED = 15;
    private const float STEP_DISTANCE = 2.5f;

    private bool _left;
    private bool _middle = true;
    private bool _right;

    void Update()
    {
        transform.position += new Vector3(0, 0, SPEED * Time.deltaTime);

        if (_middle)
        {
            Left();
            Right();
        }
        if (_left)
            Right();
        if (_right)
            Left();
    }

    private void Right()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(STEP_DISTANCE, 0);
            if (_middle)
            {
                _right = true;
                _middle = false;
            }
            if (_left)
            {
                _left = false;
                _middle = true;
            }
            Debug.Log($"L {_left} M {_middle} R {_right}");
        }
    }

    private void Left()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position -= new Vector3(STEP_DISTANCE, 0);
            if (_middle)
            {
                _left = true;
                _middle = false;
            }
            if (_right)
            {
                _right = false;
                _middle = true;
            }
            Debug.Log($"L {_left} M {_middle} R {_right}");
        }
    }
}