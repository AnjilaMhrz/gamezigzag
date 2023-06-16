using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BallSelectionUI : MonoBehaviour
{
    public GameObject buttonPanel;
    private bool hasMadeSelection = false;
    
    
    
    void Start()
    {
        buttonPanel.SetActive(true);
    }

    public void ShowBallSelection()
    {
        buttonPanel.SetActive(true);
    }

    public void HideBallSelection()
    {
        buttonPanel.SetActive(false);
    }

    public void SelectBall()
    {
        hasMadeSelection = true;
    }

    public bool HasMadeSelection()
    {
        return hasMadeSelection;
    }
}