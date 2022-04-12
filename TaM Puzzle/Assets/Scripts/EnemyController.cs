using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    
    public Transform player;
    public Rigidbody2D rb;
    public bool MinotaurTurn;
    public GameObject Theseus;
    public Vector2 movement;
    public float speed;

    // Setting starting values.
    void Start()
    {
       
        MinotaurTurn = false;
        rb = this.GetComponent<Rigidbody2D>();
        speed = 1f;
        
    }

    // Calling the moving conditions methods.
    void Update()
    {
        CheckTurn();
        CheckPlayerPosition();

    }
    
    // Gets the variable PlayerTurn from PlayerController and checks it's value. 
    public void CheckTurn()
    {

        bool pTurn = Theseus.GetComponent<PlayerController>().PlayerTurn;
        
            if (pTurn == false)
            {
                MinotaurTurn = true;
            }
            else
                MinotaurTurn = false;
        
    }

    //Compares the player's position and Minotaur's current position to get the distance.
    public void CheckPlayerPosition()
    {
  
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;    
        if (MinotaurTurn == true)
        {
            MoveMinotaur(direction);
        }
    }

    //Moves the Minotaur in player's direction.
    public void MoveMinotaur(Vector2 PDirection)
    { 
     rb.MovePosition((Vector2)transform.position + (PDirection * speed * Time.deltaTime));
    }
}
