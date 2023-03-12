using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scorecounter;
    public float MaxCannonBallCount;
    public GameObject WIN;
    public string thisScene;
    public Image HPBar;
    public AudioSource musicc;
    public Toggle toggg;

    private void Start()
    {
        
    }

    private void Update()
    {
        MaxCannonBallCount = PlayerPrefs.GetFloat("MaxStarCount", 0);

        var CurrentStarCount = PlayerPrefs.GetFloat("StarCount", 0);

        scorecounter.text = "Health: " + CurrentStarCount * 100 + "/" + MaxCannonBallCount * 100;

        if (CurrentStarCount <= 0)
        {
            WIN.SetActive(true);
            Time.timeScale = 0;
            scorecounter.gameObject.SetActive(false);
        }

        float hp = (CurrentStarCount / MaxCannonBallCount);
        HPBar.fillAmount = hp;
        Debug.Log("hp = " + hp);
    }

    public void Restart()
    {
        SceneManager.LoadScene(thisScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MuteMusic()
    {
        if (toggg.isOn == true)
        {
            musicc.volume = 0.4f;
        }
        else
        {
            musicc.volume = 0f;
        }
    }
}
