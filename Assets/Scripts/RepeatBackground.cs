using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 StartPos;
    private float repeatWidth;
    public int speed =15;
    public float time;
    void Start()
    {
        StartPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.y / 2;
        Debug.Log(repeatWidth);

        
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (GameManager.gameManagerInstance.isGameActive)
        {
            MoveBacground();
        }
        if (time > 10.0f)
        {
            speed += 5;
            time = 0;
        }

    }

    public void MoveBacground()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < -50)
        {

            transform.position = StartPos;
        }
    }
}
