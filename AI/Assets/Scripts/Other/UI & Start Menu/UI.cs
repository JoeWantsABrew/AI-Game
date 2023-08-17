using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI healthCounter;
    public float MaxHealth;
    public GameObject WIN;
    public string thisScene;
    public string OverWorld = "OverWorld";
    public Image HPBar;
    public AudioSource musicc;
    public Toggle toggg;
    // text bubble
    public TextMeshProUGUI StarPowerText;

    public bool StartAnim;

    public void Start()
    {
        Time.timeScale = 1;
        if (StartAnim)
        {
            CamFollow camer = FindObjectOfType<CamFollow>();
            camer.target = FindObjectOfType<HealthManager>().gameObject.transform;
            Invoke(nameof(FocusPlayer), 2f);
            Debug.Log("Camera Moved?");
        }
    }

    public void FocusPlayer()
    {
        CamFollow camer = FindObjectOfType<CamFollow>();
        camer.target = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }

    private void Update()
    {
        MaxHealth = PlayerPrefs.GetInt("MaxBossHealth", 69);

        var CurrentHealth = PlayerPrefs.GetInt("BossHealth", 69);

        healthCounter.text = "" + CurrentHealth;

        if (CurrentHealth <= 0)
        {
            if(PlayerPrefs.GetString("FinalPhase") == "true")
            {
                Invoke("Win", 5);
            }
        }

        float hp = (CurrentHealth / MaxHealth);
        HPBar.fillAmount = hp;
        Debug.Log("hp = " + hp);
        //sets the text bubble to the variable "starpower"
        StarPowerText.text = "" + PlayerPrefs.GetInt("StarPower");
    }

    public void GoBackToWorld()
    {
        SceneManager.LoadScene(OverWorld);
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
    public void Win()
    {
        WIN.SetActive(true);
        Time.timeScale = 0;
        healthCounter.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
}
