using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerContoller : NetworkBehaviour {

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
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
			transform.Translate (new Vector3 (0f, 0.05f, 0f));
		}
		if (Input.GetKey (KeyCode.DownArrow)|| Input.GetKey(KeyCode.S)){
			transform.Translate (new Vector3 (0f, -0.05f, 0f));
		}
		if (Input.GetKey (KeyCode.RightArrow)|| Input.GetKey(KeyCode.D)){
			transform.Translate (new Vector3 (0.05f, 0f, 0f));
		}
		if (Input.GetKey (KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A)){
			transform.Translate (new Vector3 (-0.05f, 0f, 0f));
		}
	}
}
