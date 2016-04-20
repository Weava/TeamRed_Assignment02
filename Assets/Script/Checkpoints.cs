using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {
	static Transform player;
	static Transform test;
	int num;
	void  Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void  OnTriggerEnter ( Collider other  )
	{
		if (other.tag == "Player") {
			print ("HELLLOO");
		}
		//Is it the Player who enters the collider?
		if (!other.CompareTag("Player")) 
			return; //If it's not the player dont continue
		
		if (transform == CarCheckpoint.checkpointA[CarCheckpoint.currentCheckpoint].transform) 
		{
			//Check so we dont exceed our checkpoint quantity
			if (CarCheckpoint.currentCheckpoint + 1 < CarCheckpoint.checkpointA.Length) 
			{
				//Add to currentLap if currentCheckpoint is 0
				if(CarCheckpoint.currentCheckpoint == 0)
					CarCheckpoint.currentLap++;
				CarCheckpoint.currentCheckpoint++;
			} 
			else 
			{
				//If we dont have any Checkpoints left, go back to 0
				CarCheckpoint.currentCheckpoint = 0;
			}
			print ("Checkpoint: " + (CarCheckpoint.currentCheckpoint) + " Lap: " + (CarCheckpoint.currentLap));
		}


	}

}
	