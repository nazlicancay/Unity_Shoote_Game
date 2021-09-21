using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragFingerMove : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;
    public GameObject Bullet;
    public GameObject firePoint;
    public Camera mainCamera;
    public static DragFingerMove Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        StartCoroutine(SpawnTarget());

      
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0 && GameManager.gameManagerInstance.isGameActive)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 10);
            
            touchPosition = mainCamera.ScreenToWorldPoint(touchPos);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
           
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }

           
        }

       
    }
    IEnumerator SpawnTarget()
    {
        while (GameManager.gameManagerInstance.isGameActive)
        {
            yield return new WaitForSeconds(GameManager.gameManagerInstance.BulletSpeed);
            Instantiate(Bullet,firePoint.transform.position, Quaternion.identity);


        }

    }

    public void ClosePowerUp()
    {
        Invoke(nameof(CloseInvokePowerUp),8);



    }

    private void CloseInvokePowerUp()
    {
        GameManager.gameManagerInstance.hasPowerUp = false;

    }
}

