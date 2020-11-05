using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePacman : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 destination;
    // Start is called before the first frame update
    void Start()
    {
        destination = this.transform.position;
    }

    void FixedUpdate()
    {
        Vector2 newPos = Vector2.MoveTowards(this.transform.position, destination, speed);
        GetComponent<Rigidbody2D>().MovePosition(newPos);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            destination = (Vector2)transform.position + Vector2.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            destination = (Vector2)transform.position + Vector2.left;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            destination = (Vector2)transform.position + Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            destination = (Vector2)transform.position + Vector2.down;
        }
        Vector2 dir = destination - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }
}
