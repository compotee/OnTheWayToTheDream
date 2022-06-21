using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveImput;
    private Rigidbody2D rb;
    private bool facingRight = true;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveImput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveImput * speed, rb.velocity.y);

        if (facingRight = false && moveImput < 0)
            Flip();
        else if (facingRight == true && moveImput > 0)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= (-1);
        transform.localScale = Scaler;
    }
}
