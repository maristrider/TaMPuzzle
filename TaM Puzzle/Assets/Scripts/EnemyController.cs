using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public bool MinotaurTurn;
    PlayerController PController;
    public Vector2 movement;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
       
        MinotaurTurn = false;
        rb = this.GetComponent<Rigidbody2D>();
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerPosition();
        CheckTurn();
    }

    public void CheckTurn()
    {
        if (!PController.PlayerTurn)
        {
            MinotaurTurn = true;
        }
        else
            MinotaurTurn = false;
    }
    public void CheckPlayerPosition()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;    
        if (MinotaurTurn)
        {
            MoveMinotaur(direction);
        }
    }

    public void MoveMinotaur(Vector2 PDirection)
    { 
     rb.MovePosition((Vector2)transform.position + (PDirection * speed * Time.deltaTime));
    }
}
