using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;
    public float speed = 0.1f;
    private void FixedUpdate()
    {
        if(!(Mathf.Abs(this.transform.position.x - waypoints[cur].position.x)<0.01 && Mathf.Abs(this.transform.position.y - waypoints[cur].position.y) < 0.01))
        {
            Vector2 newPos = Vector2.MoveTowards(this.transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(newPos);
        }
        else
        {
            cur = (cur + 1) % waypoints.Length;
        }
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Pacman")
        {
            Destroy(collision.gameObject);
        }
    }
}
