using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool PlayerTurn;
    public Vector3 origPos;
    public Rigidbody2D rb;
    public int MC;
    public GameObject Minotaur;
    public bool mOver;

    // Sets starting values.
    void Start()
    {
       rb = this.GetComponent<Rigidbody2D>();
       PlayerTurn = true;
       MC = 0;
    }

    // Input based commands.
    void Update()
    {
        CheckMoveCount();
        // Gets direction based on input.
        if (PlayerTurn == true)
        {
            origPos = transform.position;
            if ((Input.GetKey(KeyCode.UpArrow) == true) && (MC == 0))
            {
                MC = 1;
                MovePlayer("up");

            }
            if ((Input.GetKey(KeyCode.DownArrow) == true) && (MC == 0))
            {
                MC = 1;
                MovePlayer("down");

            }
            if ((Input.GetKey(KeyCode.LeftArrow) == true) && (MC == 0))
            {
                MC = 1;
                MovePlayer("left");
            }
            if ((Input.GetKey(KeyCode.RightArrow) == true) && (MC == 0))
            {
                MC = 1;
                MovePlayer("right");
            }
        }
        // Pressing W the player skips a turn.
        if (Input.GetKey(KeyCode.W))
        {
            MC = 1;
            PlayerTurn = false;
        }

    }


    public void CheckMoveCount()
    {
        mOver = Minotaur.GetComponent<EnemyController>().MinotaurTurn;
        if (MC == 1)
        {
            if (mOver == true)
            {
                MC = 0;
            }
        }
    }



 
 //Moves player one square
  public  void MovePlayer(string direction)
    {


      

            if (direction == "up")
            {
                rb.transform.Translate(0, 1, 0);
                // transform.position = new Vector3(origPos.x, origPos.y + 1, 0);
            }
            if (direction == "down")
            {
                rb.transform.Translate(0, - 1, 0);
                //  transform.position = new Vector3(origPos.x, origPos.y - 1, 0);
            }
            if (direction == "right")
            {
                rb.transform.Translate(1, 0, 0);
                //  transform.position = new Vector3(origPos.x + 1, origPos.y, 0);
            }
            if (direction == "left")
            {
                rb.transform.Translate(- 1, 0, 0);
                //  transform.position = new Vector3(origPos.x - 1, origPos.y, 0);
            }


        PlayerTurn = false;
       
      
     
    }

 
    // Behaviour of player on collisions
    public void OnCollisionEnter2D(Collision2D target)
    {
    // Game over condition
        if (target.gameObject.CompareTag("Minotaur"))
        {
            Destroy(this.gameObject);
        }
    }
}
