using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public Rigidbody2D arrow;
	public float maxFiringSpeed = 2000.0f;
	public float minFiringSpeed = 500.0f;
	public float speedIncrease = 250.0f;
	private float firingSpeed;

	// Use this for initialization
	void Start () {
		firingSpeed = minFiringSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		// Charge up the bow shot
		if (Input.GetMouseButton(0))
		{
			if (firingSpeed < maxFiringSpeed)
				firingSpeed += speedIncrease * Time.deltaTime;
		}
		// Create and release the arrow
		if (Input.GetMouseButtonUp(0))
		{
			var pos = Input.mousePosition;
			pos.z = transform.position.z - Camera.main.transform.position.z;
			pos = Camera.main.ScreenToWorldPoint(pos);

            //rotation from up axis to mouse position
			var q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
            Vector3 ints = transform.position;

            //detects if the angle will change the location of the arrow spawn.
            if (Vector3.Angle(Vector3.left, pos - transform.position) > 90)
            {
                ints.x = ints.x + 1.2f;
            }
            else if (Vector3.Angle(Vector3.left, pos - transform.position) < 90)
            {
                ints.x = ints.x - 1.2f;
            }
            
			var go = Instantiate(arrow, ints, q) as Rigidbody2D;

			var forceVec = new Vector2 (go.transform.up.x * firingSpeed, go.transform.up.y * firingSpeed);
			go.AddForce(forceVec);
			firingSpeed = minFiringSpeed;
		}

	}
}
