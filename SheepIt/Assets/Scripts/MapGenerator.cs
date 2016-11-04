using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
	[SerializeField]
	GameObject bush;
	[SerializeField]
	float maxX;
	[SerializeField]
	float maxY;
	[SerializeField]
	float minX;
	[SerializeField]
	float minY;
	[SerializeField]
	GameObject pond;
	[SerializeField]
	GameObject rock;

	List<GameObject> objectsOnMap;

	// Use this for initialization
	void Start()
	{
		objectsOnMap = new List<GameObject>();
		GenerateMap();
		Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	void GenerateMap()
	{
		for(int i = 0; i < 6; i++)
		{
			bool foundNewPos = true;
			Vector3 pos = new Vector3();
			do
			{
				foundNewPos = true;
				pos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), -.1f);

				foreach(GameObject g in objectsOnMap)
				{
					if((Mathf.Abs(pos.x - g.transform.position.x) < 2f) && (Mathf.Abs(pos.y - g.transform.position.y) < 2f))
					{
						foundNewPos = false;
					}
				}

			} while(!foundNewPos);

			if(i < 2)
			{
				GenerateBush
				(pos);
			}
			else if(i < 4)
			{
				GeneratePond(pos);
			}
			else
			{
				GenerateRock(pos);
			}
		}

		for(int i = 0; i < 3; i++)
		{
			bool foundNewPos = true;
			Vector3 pos = new Vector3();
			do
			{
				foundNewPos = true;
				pos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), -.1f);

				foreach(GameObject g in objectsOnMap)
				{
					if((Mathf.Abs(pos.x - g.transform.position.x) < 2f) && (Mathf.Abs(pos.y - g.transform.position.y) < 2f))
					{
						foundNewPos = false;
					}
				}

			} while(!foundNewPos);

			float rand = Random.Range(0.0f, 1.0f);

			if(rand < 0.25f)
			{
				GenerateBush(pos);
			}
			else if(rand < 0.75f)
			{
				GeneratePond(pos);
			}
			else
			{
				GenerateRock(pos);
			}
		}
	}

	void GenerateBush(Vector3 pos)
	{
		GameObject g = Instantiate(bush, pos, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f))) as GameObject;
		objectsOnMap.Add(g);
	}

	void GeneratePond(Vector3 pos)
	{
		GameObject g = Instantiate(pond, pos, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f))) as GameObject;
		objectsOnMap.Add(g);
	}

	void GenerateRock(Vector3 pos)
	{
		GameObject g = Instantiate(rock, pos, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f))) as GameObject;
		objectsOnMap.Add(g);
	}
}