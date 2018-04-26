using UnityEngine;

// Class for camera control for player tokens
public class FollowTokens : MonoBehaviour {
    public Transform player;		// Object to follow
	
	// Updates and transforms the camera position based on the position of the player token
    // Only moves along the x-axis.
	void LateUpdate () {
        Vector3 pos = new Vector3(player.position.x + 9, transform.position.y, player.position.z);
        transform.position = pos;
    }
}
