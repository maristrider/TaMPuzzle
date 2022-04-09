using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Transform movePoint;
    public bool PlayerTurn;
    public Rigidbody2D rb;
    public bool IsMoving;
    public Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
       rb = this.GetComponent<Rigidbody2D>();
       movePoint.parent = null;
        moveSpeed = 1f;
        PlayerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTurn)
        {
            if (Input.GetKey(KeyCode.UpArrow) && !IsMoving)
                StartCoroutine(MovePlayer(Vector3.up));
            if (Input.GetKey(KeyCode.DownArrow) && !IsMoving)
                StartCoroutine(MovePlayer(Vector3.down));
            if (Input.GetKey(KeyCode.LeftArrow) && !IsMoving)
                StartCoroutine(MovePlayer(Vector3.left));
            if (Input.GetKey(KeyCode.RightArrow) && !IsMoving)
                StartCoroutine(MovePlayer(Vector3.right));
        }

}

    void FixedUpdate()
    {

        
    }

  public  IEnumerator MovePlayer(Vector3 direction)
    {
        IsMoving = true;

        origPos = transform.position;
        targetPos = origPos + direction;
        float elapsedTime = 0;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        IsMoving = false;
        PlayerTurn = false;
    }

    public void OnCollisionEnter2D(Collision2D target)
    {

        if (target.gameObject.CompareTag("Minotaur"))
        {
            Destroy(gameObject);
        }
    }
}
