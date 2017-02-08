using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    public float deathTime;
    private Rigidbody2D charBody;
    private GameObject parent;
    private Vector3 parentOffset;
    private Rigidbody2D charbody;
    private float timer;

    public int damage = 5;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        charBody = GetComponent<Rigidbody2D>();
        parent = null;
        parentOffset = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Lifespan of arrow
        Lifespan();

        // Make arrow face direction it is moving
        transform.up = Vector3.Slerp(transform.up, charBody.velocity.normalized, 2.0f * Time.deltaTime);

        if (parent != null)
            FollowParent();
    }

    public void Lifespan()
    {
        if (timer > deathTime)
            Destroy(gameObject);
    }

	void OnCollisionEnter2D(Collision2D other)
	{
        if (timer < 2.25f)
        {
            if (other.gameObject.tag.Equals("Enemy"))
            {
                // Damage the enemy
            }
            else if (other.gameObject.tag.Equals("Player"))
            {
                HealthScript health = other.gameObject.GetComponentInChildren<HealthScript>();
                health.takeDamage(damage);
                Destroy(gameObject, 0.5f);
            }
        }

		//Stop the arrow
		charBody.velocity = Vector2.zero;

		// Make arrow a child of object it hit
		parent = other.gameObject;
		parentOffset = transform.position - other.gameObject.transform.position;

        // Turn off its collider/physics since it hit something
        //charBody.isKinematic = true;
    }

    // When arrow hits object it sticks to it
    void FollowParent()
	{
		transform.position = parent.transform.position + parentOffset;
	}
}
