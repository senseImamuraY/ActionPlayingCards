using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour
{
    private bool firstPush = false;
    public void PressStart()
    {
        Debug.Log("Press Start!");

        if (!firstPush)
        {
            firstPush = true;
            Debug.Log("Go to a next log");
            SceneManager.LoadScene("SampleScene");
        }
    }
}
