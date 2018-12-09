using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class backToMenu : MonoBehaviour {


    private IEnumerator czekanie;
    // Use this for initialization
    void Start () {
        czekanie = Wait();
        StartCoroutine(czekanie);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        // Debug.Log("ok");
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }




}
