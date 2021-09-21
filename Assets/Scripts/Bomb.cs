using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
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
        if (other.gameObject.CompareTag("Bullet") && gameObject.transform.position.y <6 )
        {
            GameManager.gameManagerInstance.isGameActive = false;
        
            Debug.Log("Bomb");
        }
    }
}
