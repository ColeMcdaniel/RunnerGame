using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform groundGenerator;
    private Vector3 groundStartPoint;

    public PlayerMovement thePlayer;
    private Vector3 playerStartPoint;

	// Use this for initialization
	void Start ()
    {
        groundStartPoint = groundGenerator.position;
        playerStartPoint = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        thePlayer.transform.position = playerStartPoint;
        groundGenerator.position = groundStartPoint;
        thePlayer.gameObject.SetActive(true);
    }
}
