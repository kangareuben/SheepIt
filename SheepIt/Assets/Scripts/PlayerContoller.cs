using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerContoller : NetworkBehaviour {

    public float movingSpeed = 10f;
    
    // Use this for initialization
	void Start () {
	
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<SpriteRenderer>().color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
			return;
		}

		CheckForInput ();
	}

	void CheckForInput()
	{
        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerposition = transform.position;
        Vector2 speed2 = mouseposition - playerposition;
        speed2.Normalize();

        if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = speed2 * movingSpeed;
		}

        Vector3 movingDir = new Vector3(speed2.x, speed2.y, 0f);
        float angle = Mathf.Atan2(movingDir.y, movingDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
	}
}