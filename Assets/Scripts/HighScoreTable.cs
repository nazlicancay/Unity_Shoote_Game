using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    // Start is called before the first frame update
    int index;

    private void Awake()
    {
       index = PlayerPrefs.GetInt("myList_count");
        Debug.Log(index);
        Debug.Log("liste1" + PlayerPrefs.GetInt("my_list_0"));
        Debug.Log("liste2"+PlayerPrefs.GetInt("my_list_1"));
        for (int i = 0; i< index; i++)
        {
           Debug.Log("puan : "+ PlayerPrefs.GetInt("my_list_" ));
            

        }
      


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
