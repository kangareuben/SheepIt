using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerContoller : NetworkBehaviour
{
    public float movingSpeed = 10f;

    [SyncVar]
    public string username = "Player";
    [SyncVar]
    public Color playerColor;
    [SyncVar]
    public TextMesh textName = null;

    // Use this for initialization
    void Start()
	{
        textName = GetComponentInChildren<TextMesh>();
        textName.text = username;
        textName.color = playerColor;

		Vector3 temp = transform.position;
		temp.z = -0.1f;
		transform.position = temp;
    }


    public override void OnStartLocalPlayer()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		if(!isLocalPlayer)
		{
			return;
		}
        //textName.GetComponent<TextMesh>().text = username;
        CheckForInput();
		ClampPosition();
	}

	void CheckForInput()
	{
        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerposition = transform.position;

		if(Vector2.Distance(mouseposition, playerposition) > 0.05f)
		{
			Vector2 speed2 = mouseposition - playerposition;
			speed2.Normalize();

			if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			{
				GetComponent<Rigidbody2D>().velocity = speed2 * movingSpeed;
			}

			Vector3 movingDir = new Vector3(speed2.x, speed2.y, 0f);
			float angle = Mathf.Atan2(movingDir.y, movingDir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
		else
		{
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
	}

	void ClampPosition()
	{
		if (transform.position.x < -9f) {
			transform.position = new Vector3 (-9f, transform.position.y, transform.position.z);
		}
		if (transform.position.x > 9f) {
			transform.position = new Vector3 (9f, transform.position.y, transform.position.z);
		}
		if (transform.position.y < -5f) {
			transform.position = new Vector3 (transform.position.x, -5f, transform.position.z);
		}
		if (transform.position.y > 5f) {
			transform.position = new Vector3 (transform.position.x, 5f, transform.position.z);
		}
	}
}