using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour 
{
	public GameObject theGround;
	public Transform generationPoint;
	public float distanceBetween;

	private float groundWidth;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public GameObject[] theGrounds;
	private int groundSelector;
	private float[] groundWidths;

	//public ObjectPooler theObjectPool;


	// Use this for initialization
	void Start () 
	{
//		groundWidth = theGround.GetComponent<BoxCollider2D> ().size.x;

		groundWidths = new float[theGrounds.Length];

		for (int i = 0; i < theGrounds.Length; i++) 
		{
			groundWidths [i] = theGrounds [i].GetComponent<BoxCollider2D>().size.x;
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (transform.position.x < generationPoint.position.x) 
		{
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			groundSelector = Random.Range (0, theGrounds.Length);

			transform.position = new Vector3 (transform.position.x + groundWidths[groundSelector] + distanceBetween, transform.position.y, transform.position.z);

			Instantiate (/*theGround, */ theGrounds[groundSelector], transform.position, transform.rotation);

//			GameObject newGround = theObjectPool.GetPooledObject();

//			newGround.transform.position = transform.position;
//			newGround.transform.rotation = transform.position;
//			newGround.SetActive (true);
		}
	}
}
