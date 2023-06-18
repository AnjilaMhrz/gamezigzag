using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSelectionButton : MonoBehaviour
{

  private Button button;
private GameManager gameManager;
    
 public GameObject ballPrefab;
    
    

    void Start()
    {
          button = GetComponent<Button>();
        button.onClick.AddListener(SelectBall);

         gameManager = GameManager.instance;
    }

    private void SelectBall()
    {
        gameManager.SelectBall(ballPrefab);
    }
}
