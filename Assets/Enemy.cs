using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public float seeDistance = 2f;
    public Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
        {
            transform.right = target.transform.position - transform.position;
            transform.Translate(new Vector2(0, speed * Time.deltaTime));
        }
        else
        {
            //idle
        }
    }

    public void TakeDamage(int damage) 
    {
        health -= damage;
    }
}
