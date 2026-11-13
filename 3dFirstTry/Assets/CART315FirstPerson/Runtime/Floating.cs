
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatHeight = 0.2f;
    public float floatSpeed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.localPosition = startPosition + new Vector3(0, newY, 0);
    }
}
