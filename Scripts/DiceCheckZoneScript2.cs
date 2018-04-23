using UnityEngine;
using UnityEngine.UI;

public class DiceCheckZoneScript2 : MonoBehaviour
{
    Vector3 diceVelocity;
    public Sprite[] DiceImage2;
    public bool startRolling2;
    public bool diceOnBoard2;

    private void Start()
    {
        startRolling2 = false;
        diceOnBoard2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = DiceScript2.diceVelocity;
    }

    void OnTriggerStay(Collider col)
    {
        diceOnBoard2 = false;
        if (startRolling2 == true)
        {
            if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
            {
                switch (col.gameObject.name)
                {
                    case "Side2.1":
                        DiceNumberTextScript.diceNumber2 = 6;
                        GameObject.Find("DiceIcon2").GetComponent<Image>().sprite = DiceImage2[5];
                        break;
                    case "Side2.2":
                        DiceNumberTextScript.diceNumber2 = 5;
                        GameObject.Find("DiceIcon2").GetComponent<Image>().sprite = DiceImage2[4];
                        break;
                    case "Side2.3":
                        DiceNumberTextScript.diceNumber2 = 4;
                        GameObject.Find("DiceIcon2").GetComponent<Image>().sprite = DiceImage2[3];
                        break;
                    case "Side2.4":
                        DiceNumberTextScript.diceNumber2 = 3;
                        GameObject.Find("DiceIcon2").GetComponent<Image>().sprite = DiceImage2[2];
                        break;
                    case "Side2.5":
                        DiceNumberTextScript.diceNumber2 = 2;
                        GameObject.Find("DiceIcon2").GetComponent<Image>().sprite = DiceImage2[1];
                        break;
                    case "Side2.6":
                        DiceNumberTextScript.diceNumber2 = 1;
                        GameObject.Find("DiceIcon2").GetComponent<Image>().sprite = DiceImage2[0];
                        break;
                }
                diceOnBoard2 = true;
            }
        }
    }
}
