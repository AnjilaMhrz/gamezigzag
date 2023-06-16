using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSelectionButton : MonoBehaviour
{
    private Button button;
    public Material ballMaterial;
    
    

    void Start()
    {
          button = GetComponent<Button>();
        button.onClick.AddListener(SelectBall);
    }

    private void SelectBall()
    {
        GameManager.instance.SelectBall(ballMaterial);
    }
}
