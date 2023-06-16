using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcolorchanger : MonoBehaviour
{
    private Renderer ballRenderer;

    private void Awake()
    {
        ballRenderer = GetComponent<Renderer>();
    }

    
    public void ChangeBallMaterial(Material newMaterial)
    {
        Debug.Log("Material select");


        if (ballRenderer != null)
        {
            ballRenderer.sharedMaterial = newMaterial;
        }
       
    }

     
}
