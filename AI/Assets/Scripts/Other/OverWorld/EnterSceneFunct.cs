using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterSceneFunct : MonoBehaviour
{
    public string SceneName;

    public void EnterScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
