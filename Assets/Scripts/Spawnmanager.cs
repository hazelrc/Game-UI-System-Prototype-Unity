using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawnmanager : MonoBehaviour
{
    public List<GameObject> fruits;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public GameObject gameScreen;
    public Button restartText;
    private AudioSource mainMusic;
    private int score;
    private int lives = 3;
    public bool isGameOver = false;
    public AudioClip goodSound;
    public AudioClip badSound;
    private AudioSource audioSource;
    public bool goodIsPressed;
    public bool badIsPressed;
    public bool isGameActive = false;
    private float spawnRate = 1.5f;
    public GameObject pauseScreen;
    private bool paused;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mainMusic = GameObject.Find("Main Camera").gameObject.GetComponent<AudioSource>();
        

    }

    void ChangedPause() {
        if(!paused) {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void setGoodIsPressed(bool condition) {
        goodIsPressed = condition;
    }

    public void setBadIsPressed(bool condition) {
        badIsPressed = condition;
    }

    public void StartGame(int difficulty) {
        isGameActive = true;
        spawnRate = spawnRate / difficulty;
        score = 0;
        lives = 3;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
        StartCoroutine(SpawnTarger());
        titleScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(true);  

    }

    public void setLives(int value) {
        lives -= value;
        livesText.text = "Lives: " + lives;
    }



    public void setScore(int value) {
        score += value;
        scoreText.text = "Score: " + score;
    }

    public void setGameOver(bool condition) {
        isGameOver = condition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive) {
            ChangedPause();
        }
        if (lives == 0) {
            gameOver();
        }
        if (goodIsPressed == true) {
            audioSource.PlayOneShot(goodSound);
            goodIsPressed = false;
        }

        if(badIsPressed == true) {
            audioSource.PlayOneShot(badSound);
            badIsPressed = false;
        }
    }

    public IEnumerator SpawnTarger() {
        while (!isGameOver) {
            yield return new WaitForSeconds(spawnRate);
            fruitSpawner();
        }
    }

    public bool getGameOver() {
        return isGameOver;
    }

    private void fruitSpawner() {
        int random = Random.Range(0, fruits.Count);
        Instantiate(fruits[random]);
    }

    public void gameOver() {
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        isGameOver = true;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
