using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSelectionButton : MonoBehaviour
{
    private Button button;
    public Material ballMaterial;
    public int ballIndex;
    private ballcolorchanger ballMaterialChanger;
    

    void Start()
    {
         button = GetComponent<Button>();
        button.onClick.AddListener(SelectBall);
        ballMaterialChanger = FindObjectOfType<ballcolorchanger>();
    }

    private void SelectBall()
    {
        GameManager.instance.SelectBall(ballMaterial);
        GameManager.instance.SetBallMaterialChanger(ballMaterialChanger);
    }
}
