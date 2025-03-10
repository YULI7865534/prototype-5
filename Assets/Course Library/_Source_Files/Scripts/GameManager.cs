using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
       private float spawnRate = 1.0f;
       
       public TextMeshProUGUI scoreText;

       public int score;

       public List<GameObject> targets;

       public bool isGameActive;

       public GameObject gameOverText;

       public Button restartButton;

        public GameObject titleScreen;

       public GameObject tittleScreen;
        
   
      

    // Start is called before the first frame update
    void Start()
    {
        
          
    }
    
    
    
     
    IEnumerator SpawnTarget() 
    {
        while (isGameActive)
        {
             yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd) 
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        
    }

    public void GameOver() 
    {
      isGameActive = false;
       gameOverText.gameObject.SetActive(true);
       restartButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   


    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        gameOverText.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
