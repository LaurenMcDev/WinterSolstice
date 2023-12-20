using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public string scenemain, sceneStory, scenecontrols, mainMenu;
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

    public void storyscene()
    {
        SceneManager.LoadScene(sceneStory);
    }    

    public void loadMenu()
    {
        SceneManager.LoadScene(mainMenu);
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
