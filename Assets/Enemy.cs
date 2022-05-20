using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float TimeBtwAttack;
    public float startTimeBtwAttack;
    public int damage = 1;
    public int health;
    public float stopTime;
    public float startStopTime;
    public float normalSpeed;

    public Transform pos1, pos2;
    public float speed;
    public Transform target;
    public static float Distance;
    public Transform startPos;
    Vector3 nextPos;
    public bool faceRight = true;
    public Vector2 moveVector;
    private PlayerMove player;

    void Start()
    {
        nextPos = startPos.position;
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        normalSpeed = speed;
        player = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else 
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
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
        stopTime = startStopTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }

    public void OnEnemtAttack() 
    {
        player.health -= damage;
        TimeBtwAttack = startTimeBtwAttack;
    }
}
