using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 25f;
    public float jumpForce = 5;
    public float movementForce = 0.5f;

    private Rigidbody2D charBody;
    public string collisionLayerName = "Ground";
    private int layerMask;

    GameObject player;
    int collidedWithPlayer;
    
    // Use this for initialization
    void Start ()
    {
        charBody = GetComponent<Rigidbody2D>();
        layerMask = LayerMask.NameToLayer(collisionLayerName);
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (charBody.IsTouchingLayers(layerMask))
        {
            if ((gameObject.transform.position.x - player.transform.position.x) < 5 && (gameObject.transform.position.x - player.transform.position.x) > 0)
            {
                if (collidedWithPlayer == 0)
                {
                    Move(-1, 1);
                }
            }
            else if ((gameObject.transform.position.x - player.transform.position.x) > -5 && (gameObject.transform.position.x - player.transform.position.x) < 0)
            {
                if (collidedWithPlayer == 0)
                {
                    Move(1, 1);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            collidedWithPlayer = 1;
            float savedTime = Time.time;
            if(Time.time - savedTime  >= 3.0f)
            {
                collidedWithPlayer = 0;
            }
        }

    }

    public void Move(int move, int moving)
    {
        if (moving == 1)
        {
            //facingDir(move);
            charBody.velocity = new Vector2(move * movementForce, charBody.velocity.y);
        }
        else if (moving == 0)
        {
            return;
        }
    }

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
