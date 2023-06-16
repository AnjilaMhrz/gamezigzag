using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
     public static GameManager instance;
    public bool gameOver;

    public GameObject ball;
    public List<Material> ballMaterials;
    private int selectedBallIndex;
    private bool hasPlayedGameOverSound = false;
    private ballcolorchanger ballMaterialChanger;
    public BallSelectionUI ballSelectionUI;
    private bool hasMadeBallSelection = false;
    
    public AudioSource audioSource;



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
        ChangeBallMaterial();
        ballSelectionUI.ShowBallSelection();
        
    }

    // Update is called once per frame
    void Update()
    {
         // Check if the game is not yet started, the player has made a ball selection, and the player clicks on the ball selection UI buttons
       if (!gameOver && hasMadeBallSelection)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hitCollider = Physics2D.OverlapPoint(clickPosition);

                if (hitCollider != null && hitCollider.CompareTag("BallSelectionButton"))
                {
                    StartGame();
                }
            }
        }
        
    }
    public void StartGame()
    {
         ballSelectionUI.HideBallSelection();
        UiManager.instance.GameStart();
        ScoreManager.instance.startScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatform();
    }
    public void GameOver()
    {

        
        UiManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        Debug.Log("sssss");
         if (!hasPlayedGameOverSound) // Check if the game over sound has not been played yet
        {
            audioSource.Play(); // Play the game over sound
            hasPlayedGameOverSound = true; // Set the flag to indicate that the sound has been played
        }
        gameOver=true;
        
    }

    public void NextBall()
    {
         selectedBallIndex = (selectedBallIndex + 1) % ballMaterials.Count; // Increment the selected ball index and wrap around
        ChangeBallMaterial();
        ballSelectionUI.HideBallSelection();
    }

    

  public void SelectBall(Material ballMaterial)
    {
        selectedBallIndex = ballMaterials.IndexOf(ballMaterial);
        ChangeBallMaterial();
        ballSelectionUI.HideBallSelection();
        hasMadeBallSelection = true;
    }

     public void SetBallMaterialChanger(ballcolorchanger materialChanger)
    {
        ballMaterialChanger = materialChanger;
    }


    private void ChangeBallMaterial()
    {
       if (ballMaterialChanger != null && selectedBallIndex >= 0 && selectedBallIndex < ballMaterials.Count)
        {
            Material selectedMaterial = ballMaterials[selectedBallIndex];
            ballMaterialChanger.ChangeBallMaterial(selectedMaterial);
        }
    }





}

