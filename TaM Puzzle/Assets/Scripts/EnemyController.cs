using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{

    public Transform player;
    public Rigidbody2D rb;
    public bool MinotaurTurn;
    public GameObject Theseus;
    public int MoveCount;
    public Vector3 targPos;
    public Vector3 originalPos;
    public Vector3 finalPos;
    public bool DoneMoving;
    public bool pTurn;


    // Setting starting values.
    void Start()
    {
        MinotaurTurn = false;
        rb = this.GetComponent<Rigidbody2D>();
        MoveCount = 0;

    }

    // Calling the moving conditions methods.
    void Update()
    {
        if (Theseus != null)
        {
            pTurn = Theseus.GetComponent<PlayerController>().PlayerTurn;
            if (pTurn == false)
            {
                DoneMoving = false;
                MinotaurTurn = true;
               // originalPos = rb.transform.position;
                targPos = player.position;
                MoveMinotaur();
            }
        }
    }

  

    //Moves the Minotaur in player's direction.
    public void MoveMinotaur()
    {
      // MoveCount = 0;

        originalPos = rb.transform.position;
        for (int i = 0; i < 2; i++)
        {
           
            if (Theseus != null)
            {
                
                if ((targPos.x != originalPos.x) && (MoveCount < 2))
                {

                    if ((targPos.x > originalPos.x) && (MoveCount < 2))
                    {
                        MoveCount = MoveCount + 1;
                        rb.transform.Translate(1,0,0);
                        originalPos = rb.transform.position;
                        // finalPos = new Vector3(originalPos.x + 1, originalPos.y, 0);                        
                    }
                    if ((targPos.x < originalPos.x) && (MoveCount < 2))
                    {
                        MoveCount = MoveCount + 1;
                        rb.transform.Translate(- 1, 0, 0);
                        originalPos = rb.transform.position;
                        // finalPos = new Vector3(originalPos.x - 1, originalPos.y, 0);  
                    }
                    
                }
                if ((targPos.x == originalPos.x) && (MoveCount < 2))
                {
                    if ((targPos.y > originalPos.y) && (MoveCount < 2))
                    {
                        MoveCount = MoveCount + 1;
                        rb.transform.Translate(0, 1, 0);
                        originalPos = rb.transform.position;
                        // finalPos = new Vector3(originalPos.x, originalPos.y + 1, 0);

                    }
                    if ((targPos.y < originalPos.y) && (MoveCount < 2))
                    {
                        MoveCount = MoveCount + 1;
                        rb.transform.Translate(0, -1, 0);
                        originalPos = rb.transform.position;
                        // finalPos = new Vector3(originalPos.x, originalPos.y - 1, 0);
                    }
                
                }
               
            }
            else
                break;
        }
        if (MoveCount == 2)
        {
            DoneMoving = true;
            MinotaurTurn = false;
            Theseus.GetComponent<PlayerController>().PlayerTurn = true;
         //   Theseus.GetComponent<PlayerController>().mOver = true;
        }
    }

    // Behaviour of player on collisions
    public void OnCollisionEnter2D(Collision2D target)
    {
        // Game over condition
        if (target.gameObject.CompareTag("Player"))
        {
            Destroy(target.gameObject);
        }
    }
}
