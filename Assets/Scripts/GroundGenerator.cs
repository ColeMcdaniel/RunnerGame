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

	//public GameObject[] theGrounds;
//	private int groundSelector;
//	private float[] groundWidths;

	//public ObjectPooler[] theObjectPools;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	// Use this for initialization
	void Start () 
	{
		groundWidth = theGround.GetComponent<BoxCollider2D> ().size.x;

//		groundWidths = new float[theGrounds.Length];
//
//		for (int i = 0; i < theGrounds.Length; i++) 
//		{
//			groundWidths [i] = theGrounds [i].pooledObject.GetComponent<BoxCollider2D>().size.x;
//		}
	
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (transform.position.x < generationPoint.position.x) 
		{
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			//groundSelector = Random.Range (0, theGrounds.Length);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) 
			{
				heightChange = maxHeight;
			} 
			else if (heightChange < minHeight) 
			{
				heightChange = minHeight;
			}

			transform.position = new Vector3 (transform.position.x + /*(groundWidths[groundSelector] / 2)*/ groundWidth + distanceBetween, heightChange, transform.position.z);

			Instantiate (theGround, /*theGrounds[groundSelector],*/ transform.position, transform.rotation);

//			GameObject newGround = theGrounds[groundSelector].GetPooledObject();
//
//			newGround.transform.position = transform.position;
//			newGround.transform.rotation = transform.rotation;
//			newGround.SetActive (true);
//
//			transform.position = new Vector3 (transform.position.x + (groundWidths[groundSelector] / 2), transform.position.y, transform.position.z);

		}
	}
}
