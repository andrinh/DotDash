using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xValue;
}

public class SideSwitcher : MonoBehaviour {

    public Boundary boundary;
    private float xMax;
    private float xMin;

    void Awake()
    {
        xMax = boundary.xValue;
        xMin = -boundary.xValue;
    }

    void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().position.x < xMin)
        {
            GetComponent<Rigidbody2D>().position = new Vector2(xMax, transform.position.y);
        }
        if (GetComponent<Rigidbody2D>().position.x > xMax)
        {
            GetComponent<Rigidbody2D>().position = new Vector2(xMin, transform.position.y);
        }
    }
}
