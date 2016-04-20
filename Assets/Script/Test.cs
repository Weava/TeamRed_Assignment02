using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	public static Transform[] checkpointArray;
	public Transform[] tests;
	public static int currentCheckpoint = 0;
	public static int currentLap = 0 ;
	private Vector3 startPos;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
		checkpointArray = tests;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
