﻿using UnityEngine;
using System.Collections;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;

    void Start()
    {
        dest = transform.position;
    }

    void FixedUpdate()
    {
        bool validmove = false;
        // Move closer to Destination
        

        // Check for Input if not moving
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
                validmove = true;
            }
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
                validmove = true;
            }
            if (Input.GetKey(KeyCode.DownArrow) && valid(Vector2.down))
            {
                dest = (Vector2)transform.position - Vector2.up;
                validmove = true;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && valid(Vector2.left))
            {
                dest = (Vector2)transform.position - Vector2.right;
                validmove = true;
            }
        }
        
            Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        
        // Animation Parameters
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        
        RaycastHit2D hit = Physics2D.Linecast(pos + dir*1.4f , pos);
        Debug.DrawLine(pos, pos + dir * 1.1f);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
