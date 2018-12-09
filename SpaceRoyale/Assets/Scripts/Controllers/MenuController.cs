using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int currentValue;
    public int exitValue;
    public int startValue;

    // Use this for initialization
    void Start()
    {
        currentValue = 0;
        exitValue = 180;
        startValue = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentValue++;
            if (currentValue >= exitValue)
                Application.Quit();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(currentValue < startValue)
            {
                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
            else
            {
                currentValue = 0;
            }
        }
    }
}
