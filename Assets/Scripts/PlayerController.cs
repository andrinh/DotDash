using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float yBoundary;

    private float initialVerticleTilt;

    void Start()
    {
        initialVerticleTilt = Input.acceleration.y;
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal"); //For controlling with the keyboard
        float moveHorizontal = Input.acceleration.x; //For tilt controls on phone
        //float moveVertical = Input.GetAxis("Vertical"); //For controlling with the keyboard
        float moveVertical = -1 * (initialVerticleTilt - Input.acceleration.y); //For tilt controls on phone

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        GetComponent<Rigidbody2D>().velocity = movement * speed;

        GetComponent<Rigidbody2D>().position = new Vector2(
            GetComponent<Rigidbody2D>().position.x,
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, -yBoundary, yBoundary)
        );
    }
}
