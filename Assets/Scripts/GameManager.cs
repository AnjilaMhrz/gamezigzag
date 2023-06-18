using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
     public static GameManager instance;
    public bool gameOver;

    public Transform ballSpawnPoint;
    private GameObject selectedBallPrefab;
    private int selectedBallIndex;
    private bool hasPlayedGameOverSound = false;
    public AudioSource audioSource;

   
    private CameraFollow cameraFollow; 
   

    void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
    }
    void Start()
    {
      gameOver = false;
       selectedBallIndex = 0;
        SelectBall(ballSpawnPoint.GetComponent<BallSelectionButton>().ballPrefab);
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
       
                
    }

    // Update is called once per frame
    void Update()
    {
         // Check if the game is not yet started, the player has made a ball selection, and the player clicks on the ball selection UI buttons
    //    if (!gameOver && hasMadeBallSelection)
    //     {
    //         if (Input.GetMouseButtonDown(0))
    //         {
    //             Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //             Collider2D hitCollider = Physics2D.OverlapPoint(clickPosition);

    //             if (hitCollider != null && hitCollider.CompareTag("BallSelectionButton"))
    //             {
    //                 StartGame();
    //             }
    //         }
    //     }
        // StartGame();
    }
    public void StartGame()
    {
        UiManager.instance.GameStart();
        ScoreManager.instance.startScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatform();
    }
    public void GameOver()
    {

        
        UiManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        //Debug.Log("sssss");
         if (!hasPlayedGameOverSound) // Check if the game over sound has not been played yet
        {
            audioSource.Play(); // Play the game over sound
            hasPlayedGameOverSound = true; // Set the flag to indicate that the sound has been played
        }
        gameOver=true;


        
    }

    // public void NextBall()
    // {
    //      selectedBallIndex = (selectedBallIndex + 1) % ballMaterials.Count; // Increment the selected ball index and wrap around
    //     ChangeBallMaterial();
    //     ballSelectionUI.HideBallSelection();
    // }

    

  public void SelectBall(GameObject ballPrefab)
    {
       if (selectedBallPrefab == null) // Only spawn the ball if it hasn't been selected yet
        {
            selectedBallPrefab = ballPrefab;
            SpawnBall();
            //cameraFollow.SetTarget(selectedBallPrefab.transform);
        }
    }

     private void SpawnBall()
    {
       

       if (selectedBallPrefab != null)
        {
            GameObject ball = Instantiate(selectedBallPrefab, ballSpawnPoint.transform.position, Quaternion.identity);
            ball.GetComponent<BallController>().enabled = true;
        }
    }

   




}

