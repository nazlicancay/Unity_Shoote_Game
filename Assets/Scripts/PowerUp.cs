using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    public bool powerUp = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManagerInstance.isGameActive)
        {
            MoveDownFonk();
        }
        
    }
    
    public void MoveDownFonk()
    {
        transform.position += Vector3.down* speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") && gameObject.transform.position.y < 6)
        {
            Debug.Log("PowerUp");
            GameManager.gameManagerInstance.hasPowerUp = true;
            
            DragFingerMove.Instance.ClosePowerUp();
            Destroy(gameObject);
            powerUp = true;
            StartCoroutine(PowerUpCountDown());
          
        }
    }

    IEnumerator PowerUpCountDown()
    {
        Debug.Log("PowerUpCount");
        yield return new WaitForSeconds(1);
        GameManager.gameManagerInstance.hasPowerUp = false;

    }  
}
