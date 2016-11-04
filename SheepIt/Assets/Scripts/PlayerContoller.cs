using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerContoller : NetworkBehaviour
{
    public float movingSpeed = 10f;

    [SyncVar]
    public string username = "Player";
    [SyncVar]
    public TextMesh textName = null;

    // Use this for initialization
    void Start()
	{
        textName = GetComponentInChildren<TextMesh>();

		Vector3 temp = transform.position;
		temp.z = -0.1f;
		transform.position = temp;
    }

    void OnGUI()
    {
        if (isLocalPlayer)
        {
            username = GUI.TextField(new Rect(25, Screen.height - 40, 100, 25), username);
            if (GUI.Button(new Rect(130, Screen.height - 40, 30, 25), "Set"))
            {
                print("here");
                CmdSetName(username);
            }
        }

    }

    [Command]
    public void CmdSetName(string name)
    {
        textName.GetComponent<TextMesh>().text = name;
        print(textName.GetComponent<TextMesh>().text);
    }


    public override void OnStartLocalPlayer()
	{
		GetComponent<SpriteRenderer>().color = Color.blue;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(!isLocalPlayer)
		{
			return;
		}
        //textName.GetComponent<TextMesh>().text = username;
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

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
	}
}