using UnityEngine;

public class LevelPart : MonoBehaviour
{
    private int _index;
    public int Index => _index;
    public void SetIndex(int index) => _index = index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
            gameObject.SetActive(false);
    }
}