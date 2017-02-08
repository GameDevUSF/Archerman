using UnityEngine;
using System.Collections;


public class MovementScript : MonoBehaviour
{
    private float speed = 25f;
    public float jumpForce = 5;
    public float movementForce = 5;

    bool walking;
    bool standing;

    private Rigidbody2D charBody;
    public string collisionLayerName = "Ground";
    private int layerMask;

    void Start()
    {
        charBody = GetComponent<Rigidbody2D>();
        layerMask = LayerMask.NameToLayer(collisionLayerName);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (charBody.IsTouchingLayers(layerMask))
        {
            if (Input.GetKey(KeyCode.W))
            {
                charBody.velocity = new Vector2(charBody.velocity.x, jumpForce);
            }
        }

        walking = h != 0f || v != 0f;
        standing = !walking;

        Move(h);
    }

    /// <summary>
    /// Moves the player in the plane
    /// </summary>
    /// <param name="move"></param> The input of one axis, likely x.
    public void Move(float move)
    {
        facingDir(move);
        charBody.velocity = new Vector2(move * movementForce, charBody.velocity.y);
    }

    /// <summary>
    /// Facind Direction Method, detects which way the player is facing.
    /// </summary>
    /// <param name="move"></param> The input of one axis, likely x.
    public void facingDir(float move)
    {
        if (move < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (move > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
