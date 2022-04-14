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
    public Vector3 origPos;
    public bool DoneMoving;


    // Setting starting values.
    void Start()
    {
        DoneMoving = false;
        MinotaurTurn = false;
        rb = this.GetComponent<Rigidbody2D>();
        
    }

    // Calling the moving conditions methods.
    void Update()
    {
        
       
        CheckTurn();


    }

    // Gets the variable PlayerTurn from PlayerController and checks it's value. 
    public void CheckTurn()
    {
        if (Theseus != null)
        {
            bool pTurn = Theseus.GetComponent<PlayerController>().PlayerTurn;

            if (pTurn == false)
            {
                DoneMoving = false;
                MinotaurTurn = true;
                origPos = rb.transform.position;
                targPos = player.position;
                MoveMinotaur();
            }
        }

    }


    //Moves the Minotaur in player's direction.
    public void MoveMinotaur()
    {

        MoveCount = 0;
        while (MinotaurTurn)
        {
            while (MoveCount < 2)
            {
                if (targPos.x != origPos.x)
                {

                    if ((targPos.x > origPos.x) && (MoveCount < 2))
                    {
                        transform.position = new Vector3(origPos.x + 1f, origPos.y, 0f);
                        MoveCount++;
                        origPos = rb.transform.position;
                    }
                    if ((targPos.x < origPos.x) && (MoveCount < 2))
                    {
                        transform.position = new Vector3(origPos.x - 1f, origPos.y, 0f);
                        MoveCount++;
                        origPos = rb.transform.position;
                    }
                }
                if (targPos.x == origPos.x)
                {
                    if ((targPos.y > origPos.y) && (MoveCount < 2))
                    {
                        transform.position = new Vector3(origPos.x, origPos.y + 1f, 0f);
                        MoveCount++;
                        origPos = rb.transform.position;
                    }
                    if ((targPos.y < origPos.y) && (MoveCount < 2))
                    {
                        transform.position = new Vector3(origPos.x, origPos.y - 1f, 0f);
                        MoveCount++;
                        origPos = rb.transform.position;
                    }
                }
            }
            if (MoveCount == 2)
            {
                DoneMoving = true;
                MinotaurTurn = false;
                origPos = rb.transform.position;
            }
        } 
         
        MoveCount = 0;

      
    }
}
