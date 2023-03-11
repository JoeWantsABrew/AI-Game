using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STartMenu : MonoBehaviour
{
    public List <string> GotoScene;
    
    public void ThisScene()
    {
        SceneManager.LoadScene(GotoScene[Random.Range(0, GotoScene.Count - 1)]);
    }

    public void Quitt()
    {
        Application.Quit();
    }
}
