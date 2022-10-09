using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool isPlayer1;
    public Rigidbody2D rb;
    public float speed;
    public Vector3 startPosition;


    private float movementVertical;
    private float movementHorizontal;
    private Vector3 scaleChange;

    void Start(){
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            movementVertical = Input.GetAxisRaw("Vertical2");
            movementHorizontal = Input.GetAxisRaw("Horizontal2");

            if ((rb.position.x > -0.75 && movementHorizontal > 0) || (rb.position.x <= -8 && movementHorizontal < 0))
            {
                movementHorizontal = 0;
            }

        }
        else
        {
            movementVertical = Input.GetAxisRaw("Vertical");
            movementHorizontal = Input.GetAxisRaw("Horizontal");

            if ((rb.position.x < 0.75 && movementHorizontal < 0) || (rb.position.x >= 8 && movementHorizontal > 0))
            {
                movementHorizontal = 0;
            }

        }
        //(8,3)
        //(2,1)
           
        //3 = 8a + b
        //2 = 1a + b
        //1 = 7a
        //a = 1/7

        //b = 3 - 8 * 1 / 7
        //b = 3 - 8 / 7
        //b = 13 / 7


        rb.velocity = new Vector2(movementHorizontal*speed, movementVertical*speed);

        scaleChange = new Vector3(gameObject.transform.localScale.x, Mathf.Abs(rb.position.x)*2/7 + 13/7, gameObject.transform.localScale.z);
        gameObject.transform.localScale = scaleChange;

    }

    public void Reset(){
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
