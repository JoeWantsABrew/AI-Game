using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scorecounter;
    public float MaxHealth;
    public GameObject WIN;
    public string thisScene;
    public Image HPBar;
    public AudioSource musicc;
    public Toggle toggg;
    // text bubble
    public TextMeshProUGUI StarPowerText;

    private void Start()
    {
        
    }

    private void Update()
    {
        MaxHealth = PlayerPrefs.GetInt("MaxBossHealth", 69);

        var CurrentHealth = PlayerPrefs.GetInt("BossHealth", 69);

        scorecounter.text = "" + CurrentHealth;

        if (CurrentHealth <= 0)
        {
            WIN.SetActive(true);
            Time.timeScale = 0;
            scorecounter.gameObject.SetActive(false);
        }

        float hp = (CurrentHealth / MaxHealth);
        HPBar.fillAmount = hp;
        Debug.Log("hp = " + hp);
        //sets the text bubble to the variable "starpower"
        StarPowerText.text = "" + PlayerPrefs.GetInt("StarPower");
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
