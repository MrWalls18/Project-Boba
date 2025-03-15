using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaScript : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 startPos;

    public Rigidbody2D rigidBody;
    public int velocityVar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    rigidBody.velocity = Vector2.zero;
                    startPos = touch.position;
                    gameObject.transform.position = Vector2.zero;
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;
                    gameObject.transform.position = Vector2.zero;
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    rigidBody.velocity = direction / velocityVar;
                    break;
            }
        }
    }
}
