using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool hasPowerUp;
    public GameObject[] targets;
    public bool isGameActive = true;
    private int SRangeX = 2;
    public float SpawnRate = 3.0f;
    public float SpawnRatePickUp = 4.0f;
    public bool TakeDamage = false;
    public float Damage = 10f;
    public Target target;
    public TextMeshProUGUI GameOverText;
    private float time;
    public int Score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI NewHighScore;
    public TMP_InputField playerName ;
    public Button RestartButton;
    public GameObject firePoint;
    public GameObject PowerUp;
    public GameObject Bomb;
    public Canvas Canvas;
    int previousScore;
    public string input;
    int i;
    public float BulletSpeed;
    public static GameManager gameManagerInstance;

    public List<int> Scores = new List<int>();
    public bool once;
    int[] PlayerPrefScores;
    string list;
    





    void Start()
    {
        //PlayerPrefs.SetInt("myList_count", 0);
        

        Vector3 spawnPos = new Vector3(Random.Range(-SRangeX, SRangeX), 5, 0);

        Instantiate(targets[0], spawnPos, Quaternion.identity);

        StartCoroutine(SpawnTarget());
        StartCoroutine((SpawnPickUp(PowerUp)));
        StartCoroutine((SpawnBomb(Bomb)));
        

        gameManagerInstance = this;

        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        previousScore = PlayerPrefs.GetInt("HighScore");
        once = true;



    }

    // Update is called once per frame
    void Update()
    {
       time += Time.deltaTime;
        
        if (GameManager.gameManagerInstance.TakeDamage)
        {
            target.TakeDamage(Damage);
            TakeDamage = false;
        }

        if (!isGameActive)
        {
            GameOverText.gameObject.SetActive(true);
            RestartButton.gameObject.SetActive(true);

            //Debug.Log("Score " + Score);

            Canvas.gameObject.SetActive(true);

            scoreText.text =  ( "Score\n "+Score.ToString());




            if (Score > previousScore)
            {
                NewHighScore.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                HighScore.text = ("High Score" + Score);

                PlayerPrefs.SetInt("HighScore" , Score);
            }

            else
            {
                scoreText.gameObject.SetActive(true);
                HighScore.gameObject.SetActive(true);

            }

            if (!isGameActive && once)
            {
                Scores.Add(Score);
                
                Scores.Sort();
                once = false;

                

                //PlayerPrefs.SetInt("myList_count",index);
                i = PlayerPrefs.GetInt("myList_count");
                PlayerPrefs.SetInt("myList_" + i, Scores[0]);
                PlayerPrefs.SetInt("myList_count", PlayerPrefs.GetInt("myList_count") + 1);


            }


        }
        if (time > 10.0f && SpawnRate != 1)
        {

            SpawnRate -= 0.5f;
            time =  0;
        }
        
        
        if (hasPowerUp)
        {
            BulletSpeed = 0.2f;
        }
        else
        {
            BulletSpeed = 0.5f;
        }

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(SpawnRate);
            int targetindex = Random.Range(0, targets.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-SRangeX, SRangeX), 5, 0);

            Instantiate(targets[targetindex], spawnPos, Quaternion.identity);


        }

    }
    
    IEnumerator SpawnPickUp( GameObject gameObject)
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(5);
            
            Vector3 spawnPos = new Vector3(Random.Range(-SRangeX, SRangeX), 8, 0);

            Instantiate(gameObject,spawnPos, Quaternion.identity);


        }

    }
    
     IEnumerator SpawnBomb( GameObject gameObject)
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(8);
            
            Vector3 spawnPos = new Vector3(Random.Range(-SRangeX, SRangeX), 8, 0);

            Instantiate(gameObject,spawnPos, Quaternion.identity);


        }

    }
    
    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log(input);


    }

  public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }


}
