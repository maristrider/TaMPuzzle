using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool PlayerTurn;
    public Vector3 origPos;
    public Rigidbody2D rb;
    public int MoveCount;
    public GameObject Minotaur;

    // Sets starting values.
    void Start()
    {
       rb = this.GetComponent<Rigidbody2D>();
       PlayerTurn = true;
       MoveCount = 0;
    }

    // Input based commands.
    void Update()
    {
        // Gets direction based on input.
        if (PlayerTurn)
        {
            if (Input.GetKey(KeyCode.UpArrow) && MoveCount == 0)
                MovePlayer("up");
            if (Input.GetKey(KeyCode.DownArrow) && MoveCount == 0)
             MovePlayer("down");
            if (Input.GetKey(KeyCode.LeftArrow) && MoveCount == 0)
                MovePlayer("left");
            if (Input.GetKey(KeyCode.RightArrow) && MoveCount == 0)
                MovePlayer("right");
        }
        // Pressing W the player skips a turn.
        if (Input.GetKey(KeyCode.W))
        {
            MoveCount = 0;
            PlayerTurn = false;
            Minotaur.GetComponent<EnemyController>().MinotaurTurn = true;
        }

    }

 
 //Moves player one square
  public  void MovePlayer(string direction)
    {
      
        MoveCount++;
        origPos = transform.position;

  
    if (direction == "up")
            transform.position = new Vector3(origPos.x, origPos.y + 1f, 0f);
    if (direction == "down") 
            transform.position = new Vector3(origPos.x, origPos.y - 1f, 0f);
    if (direction == "right")
            transform.position = new Vector3(origPos.x + 1f, origPos.y, 0f);
    if (direction == "left")
            transform.position = new Vector3(origPos.x - 1f, origPos.y, 0f);
     
        Minotaur.GetComponent<EnemyController>().MinotaurTurn = true;
        PlayerTurn = false;
        MoveCount = 0;
    }

 
    // Behaviour of player on collisions
    public void OnCollisionEnter2D(Collision2D target)
    {
    // Game over condition
        if (target.gameObject.CompareTag("Minotaur"))
        {
            Destroy(gameObject);
        }
    }
}
