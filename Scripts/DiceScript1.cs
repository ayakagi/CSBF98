using UnityEngine;

// Class for changing the dice rolling status and animation of rolling dice1
public class DiceScript1 : MonoBehaviour {
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    DiceCheckZoneScript1 rollingDice1;
    DiceNumberTextScript diceText;
    Player Player1Dice1;
    Player Player2Dice1;
    CamEvent camEv;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody> ();
        rollingDice1 = GameObject.FindObjectOfType<DiceCheckZoneScript1>();
        diceText = GameObject.FindObjectOfType<DiceNumberTextScript>();
        Player1Dice1 = GameObject.FindWithTag("Player1").GetComponent<Player>();
        Player2Dice1 = GameObject.FindWithTag("Player2").GetComponent<Player>();
        camEv = GameObject.FindObjectOfType<CamEvent>();
    }

    // Update is called once per frame
    void Update() {
        diceVelocity = rb.velocity;
    }

    // Roll dice1
    // When it is being rolled, camera will zoom in
	public void Roll1() {
		DiceNumberTextScript.diceNumber1 = 0;
		float dirX = Random.Range (0, 500);
		float dirY = Random.Range (0, 500);
		float dirZ = Random.Range (0, 500);
		transform.position = new Vector3 (-22, 6, 18);
		transform.rotation = Quaternion.identity;
		rb.AddForce (transform.up * 500);
		rb.AddTorque (dirX, dirY, dirZ);
        camEv.CamDice();
	}

    // Run when player hit the "Run the Dice" button
    // Show the dice1 value on screen after player rolls it
    // Update its rolling status
    public void OnClick1()
    {
        if (diceText.enabled == false)
        {
            diceText.enabled = true;
        }
        rollingDice1.startRolling1 = true; 
        Player1Dice1.isDoneRolling1 = true;
        Player2Dice1.isDoneRolling1 = true;
    }
}

