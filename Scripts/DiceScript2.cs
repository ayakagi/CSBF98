using UnityEngine;

public class DiceScript2 : MonoBehaviour {
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    DiceCheckZoneScript2 rollingDice2;
    Player PlayerDice2;
    CamEvent camEv;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody> ();
        rollingDice2 = GameObject.FindObjectOfType<DiceCheckZoneScript2>();
        PlayerDice2 = GameObject.FindObjectOfType<Player>();
        camEv = GameObject.FindObjectOfType<CamEvent>();
    }

    // Update is called once per frame
    void Update() {
        diceVelocity = rb.velocity;
    }
	
    public void Roll2() {
		DiceNumberTextScript.diceNumber2 = 0;
		float dirX = Random.Range (0, 500);
		float dirY = Random.Range (0, 500);
		float dirZ = Random.Range (0, 500);
		transform.position = new Vector3 (-19, 6, 21);
		transform.rotation = Quaternion.identity;
		rb.AddForce (transform.up * 500);
		rb.AddTorque (dirX, dirY, dirZ);
        camEv.camDice();
    }

    public void OnClick2()
    {
        rollingDice2.startRolling2 = true;  
        PlayerDice2.isDoneRolling2 = true;
    }
}

