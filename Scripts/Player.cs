using UnityEngine;

public class Player : MonoBehaviour
{
    public Tile StartPosition;
    public Tile jail;
    public Tile goToJail;
    public Tile incomeTax;
    public Tile superTax;
    public bool isDoneRolling1;
    public bool isDoneRolling2;
    public bool inJail;
    private int totalMove;
    public int salary;
    Tile CurrentPosition;
    Tile FinalPosition;
    DiceNumberTextScript player_dice;

    // Use this for initialization
    void Start()
    {
        player_dice = GameObject.FindObjectOfType<DiceNumberTextScript>();
        CurrentPosition = StartPosition;
        isDoneRolling1 = false;
        isDoneRolling2 = false;
        salary = 1500;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayerMovement()
    {
        if (isDoneRolling1 == true && isDoneRolling2 == true)
        {
            totalMove = player_dice.GetDiceTotal();
            if (totalMove != 0)
            {
                FinalPosition = CurrentPosition;
                // move token
                for (int m = 0; m < totalMove; m++)
                {
                    FinalPosition = FinalPosition.GoNextTile[0];
                    // collect salary
                    if (FinalPosition == StartPosition)
                    {
                        salary += 200;
                    }
                }
                // teleport the token
                this.transform.position = FinalPosition.transform.position;
                CurrentPosition = FinalPosition;
            }
        }

    }

    public void TeleportToJail()
    {

        if (isDoneRolling1 == true && isDoneRolling2 == true)
        {
            if (this.transform.position == goToJail.transform.position)
            {
                this.transform.position = jail.transform.position;
                CurrentPosition = jail;
                inJail = true;
            }

        }
    }

    public void IncomeTax()
    {
        if (isDoneRolling1 == true && isDoneRolling2 == true)
        {
            if (this.transform.position == incomeTax.transform.position)
            {
                salary -= 200;

            }
        }
    }

    public void SuperTax()
    {
        if (isDoneRolling1 == false && isDoneRolling2 == false)
        {
            if (this.transform.position == superTax.transform.position)
            {
                salary -= 100;

            }
        }
    }

    public int GetSalary()
    {
        return salary;
    }

}
