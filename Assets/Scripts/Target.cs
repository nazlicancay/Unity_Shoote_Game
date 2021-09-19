using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject Player;
    public float healt;
    public int speed;
    public int ShipScore;
    public bool col = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManagerInstance.isGameActive)
        {
            MoveDown();
        }
        

        if(transform.position.y < -4)
        {
            GameManager.gameManagerInstance.isGameActive = false;

           // Destroy(gameObject);
        }

        if (!GameManager.gameManagerInstance.isGameActive)
        {
            if(transform.position.y >-3)
            {
                Destroy(gameObject);
            }
           
        }

      
    }

    public void MoveDown()
    {
        transform.position += Vector3.down* speed * Time.deltaTime;
    }

    public void TakeDamage(float amount)
    {
        healt -= amount;
        if(healt <= 0)
        {
            Destroy(gameObject);
            GameManager.gameManagerInstance.Score += ShipScore;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {

            Destroy(other.gameObject);
            TakeDamage(GameManager.gameManagerInstance.Damage);

        }
        
    }

   



}
