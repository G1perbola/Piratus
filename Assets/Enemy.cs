using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public Transform pos1, pos2;
    public float speed;
    public Transform target;
    public static float Distance;
    public Transform startPos;
    Vector3 nextPos;
    public bool faceRight = true;
    public Vector2 moveVector;

    void Start()
    {
        nextPos = startPos.position;
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {

        if (health <= 0)
                {
                    Destroy(gameObject);
                }
        /* transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);*/

        if (Vector2.Distance(transform.position, target.position) < 7)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            if (transform.position == pos1.position)
            {
                nextPos = pos2.position;
                transform.localScale = new Vector2(-4, 4);
            }
            if (transform.position == pos2.position)
            {
                nextPos = pos1.position;
                transform.localScale = new Vector2(4, 4);
            }
       }
    }

    public void TakeDamage(int damage) 
    {
        health -= damage;
    }
}
