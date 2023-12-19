using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public string scenemain, sceneplay, scenecontrols;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene()
    {
        SceneManager.LoadScene(scenemain);
    }

  /*  public void loadStory()
    {
        SceneManager.LoadScene(sceneplay);
    }*/
    public void exitGame()
    {
        Application.Quit();
    }
}
