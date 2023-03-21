using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STartMenu : MonoBehaviour
{
    public string GotoScene;
    
    public void ThisScene()
    {
        SceneManager.LoadScene(GotoScene);
    }

    public void Quitt()
    {
        Application.Quit();
    }
}
