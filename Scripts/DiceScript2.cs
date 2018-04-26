using UnityEngine;

// Class for changing the dice rolling status and animation of rolling dice2
public class DiceScript2 : MonoBehaviour {
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    DiceCheckZoneScript2 rollingDice2;
    DiceNumberTextScript diceText;
    Player Player1Dice2;
    Player Player2Dice2;
    CamEvent camEv;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody> ();
        rollingDice2 = GameObject.FindObjectOfType<DiceCheckZoneScript2>();
        diceText = GameObject.FindObjectOfType<DiceNumberTextScript>();
        Player1Dice2 = GameObject.FindWithTag("Player1").GetComponent<Player>();
        Player2Dice2 = GameObject.FindWithTag("Player2").GetComponent<Player>();
        camEv = GameObject.FindObjectOfType<CamEvent>();       
    }

    // Update is called once per frame
    void Update() {
        diceVelocity = rb.velocity;
    }
	
    // Roll dice2
    // When it is being rolled, camera will zoom in 
    public void Roll2() {
		DiceNumberTextScript.diceNumber2 = 0;
		float dirX = Random.Range (0, 500);
		float dirY = Random.Range (0, 500);
		float dirZ = Random.Range (0, 500);
		transform.position = new Vector3 (-18, 6, 22);
		transform.rotation = Quaternion.identity;
		rb.AddForce (transform.up * 500);
		rb.AddTorque (dirX, dirY, dirZ);
        camEv.CamDice();
    }

    // Run when player hit the "Run the Dice" button
    // Show the dice1 value on screen after player rolls it
    // Update its rolling status
    public void OnClick2()
    {
        if (diceText.enabled == false)
        {
            diceText.enabled = true;
        }
        rollingDice2.startRolling2 = true;
        Player1Dice2.isDoneRolling2 = true;
        Player2Dice2.isDoneRolling2 = true;       
    }
}

