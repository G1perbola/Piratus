using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shotPos;
    public GameObject Bottle;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            Instantiate(Bottle, shotPos.transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            Destroy(GameObject.FindWithTag("Bullet"));
        }
    }
}
