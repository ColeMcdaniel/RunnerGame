using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject theWall;
    public Transform generationPoint;
    public float distanceBetween;

    private float wallWidth;


    // Use this for initialization
    void Start()
    {
        wallWidth = theWall.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + wallWidth + distanceBetween, transform.position.y, transform.position.z);

            Instantiate(theWall, transform.position, transform.rotation);
        }
    }
}

