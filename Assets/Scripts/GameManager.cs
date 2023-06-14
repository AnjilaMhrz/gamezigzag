using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public bool gameOver;

     public GameObject ball;
    public List<Material> ballMaterials;
    private int selectedBallIndex;

 public BallSelectionUI ballSelectionUI;
    void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
    }
    void Start()
    {
        gameOver=false;
         selectedBallIndex = 0; // Set the default ball texture index
         ChangeBallMaterial();
         ballSelectionUI.ShowBallSelection();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        gameOver=true;
    }

    public void NextBall()
    {
        selectedBallIndex = (selectedBallIndex + 1) % ballMaterials.Count;// Increment the selected ball index and wrap around
         ChangeBallMaterial();

         ballSelectionUI.HideBallSelection();
    }

    private void ChangeBallMaterial()
    {
        Renderer ballRenderer = GameObject.FindGameObjectWithTag("Ball").GetComponent<Renderer>();
        if (ballRenderer != null && ballMaterials.Count > 0)
        {
            ballRenderer.material = ballMaterials[selectedBallIndex];
        }
    }}

