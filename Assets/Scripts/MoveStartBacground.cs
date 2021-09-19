using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStartBacground : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 StartPos;
    private float repeatWidth;
    public int speed = 15;
    void Start()
    {

        StartPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.y / 2;
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * 15 * Time.deltaTime;
       

        if (transform.position.y < -50)
        {

            transform.position = StartPos;
        }

    }
}
