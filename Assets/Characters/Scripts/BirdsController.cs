using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animate;

    private float moveSpeed;
    private float jumpForce;
    private bool isJump;
    private float moveVertical;
    private float moveHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animate = gameObject.GetComponent<Animator>();

        moveSpeed = .3f;
        jumpForce = .2f;
        isJump = false;
    }

    // Update is called once per frame
    void Update()
    { 
        moveHorizontal = Input.GetAxisRaw("Horizontal");    // Using Input.GetButtonDown for mobile UI

        animate.SetFloat("IsJump", moveHorizontal);
    }

    void FixedUpdate()
    {
        rb2D.AddForce(new Vector2(0f, moveSpeed), ForceMode2D.Impulse);

        if (!isJump && moveHorizontal > 0.1f)
        {
            // rb2D.AddForce(new Vector2(jumpForce, 0f), ForceMode2D.Impulse);
            Vector3 movedPos = transform.position;
            movedPos.x += jumpForce;
            transform.position = movedPos;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "MainCamera")
        {
            ChangeDirection();
        }

        // Effect when character collide with an item
        switch(collision.tag)
        {
            case "Coin":
                // Add 1 coin
                return;
            case "Feather":
                // Shield player from 1 debuff
                return;
            case "Slow Pill":
                // Faster obstacle
                return;
            case "Bomb":
                // Player die
                return;
            case "Super Power Potion":
                // Feather + slow down obstacle
                return;
            default:
                return;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        moveSpeed *= -1;
    }
}
