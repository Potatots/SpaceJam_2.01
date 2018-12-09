using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int currentValue;
    public int exitValue;
    public int startValue;
    public Animator animator;
    public int waitTime;
    

    // public void XXXXFadeCmpl () { SceneManager.LoadScene(1, LoadSceneMode.Single); }

    // Use this for initialization
    void Start()
    {
        currentValue = 0;
        exitValue = 180;
        startValue = 30;
    }

    // Update is called once per frame
    private IEnumerator czekanie;
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
            if (currentValue < startValue)
            {
                animator.SetTrigger("FadeOutTrigger");
                czekanie = Wait();
                StartCoroutine(czekanie);
               
            }
            
            else
            {
                currentValue = 0;
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("ok");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
