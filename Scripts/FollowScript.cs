using UnityEngine;

// Class for camera control for dice
public class FollowScript : MonoBehaviour {
    public Transform FollowObject;		// Object to follow
	
	// Updates and transforms the camera position based on the position of the dice1
    // Only moves along the y-axis.
	void Update () {
        Vector3 pos = new Vector3(transform.position.x, FollowObject.position.y + 10, transform.position.z);
        transform.position = pos;
	}
}
