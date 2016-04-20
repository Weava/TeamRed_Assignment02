using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform target;
	public float distance;

	void Update(){

		transform.position = new Vector3(target.position.x-distance, target.position.y+4, target.position.z);

	}
}
