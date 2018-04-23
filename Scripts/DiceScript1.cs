using UnityEngine;

public class DiceScript1 : MonoBehaviour {
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    DiceCheckZoneScript1 rollingDice1;
    Player PlayerDice1;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody> ();
        rollingDice1 = GameObject.FindObjectOfType<DiceCheckZoneScript1>();
        PlayerDice1 = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update() {
        diceVelocity = rb.velocity;
    }

	public void Roll1() {
		DiceNumberTextScript.diceNumber1 = 0;
		float dirX = Random.Range (0, 500);
		float dirY = Random.Range (0, 500);
		float dirZ = Random.Range (0, 500);
		transform.position = new Vector3 (-21, 6, 19);
		transform.rotation = Quaternion.identity;
		rb.AddForce (transform.up * 500);
		rb.AddTorque (dirX, dirY, dirZ);
	}

    public void OnClick1()
    {
        rollingDice1.startRolling1 = true; 
        PlayerDice1.isDoneRolling1 = true;
    }
}

