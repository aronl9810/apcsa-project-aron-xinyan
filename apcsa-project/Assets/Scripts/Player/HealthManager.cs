using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public float healthAmount;
    private float initalHealthAmount;
    public Image healthBar;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [Header("Audio")]
    public AudioSource getAudio;
    public AudioClip sfx1;
    public TimerScript getTimer;
    private CursorHideShow cursorlock;

    // Start is called before the first frame update
    void Start()
    {
        initalHealthAmount = healthAmount;
        cursorlock = GetComponent<CursorHideShow>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "" + healthAmount + "/" + initalHealthAmount;
        if(healthAmount <= 0) 
        {
            getTimer.killed();
            cursorlock.SetCursorLock(false);
            SceneManager.LoadScene("Defeat");
        }

        // if(Input.GetKeyDown(KeyCode.Z)) // testing phase
        // {
        //     TakeDamage(20);
        // }
        // if(Input.GetKeyDown(KeyCode.X))
        // {
        //     Heal(5);   
        // }
        // Debug.Log(healthAmount);
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / initalHealthAmount;
        getAudio.clip = sfx1;
        getAudio.Play();
    }

    public void Heal (float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0 , initalHealthAmount);

        healthBar.fillAmount = healthAmount / initalHealthAmount;
    }

    public float getMaxHealth(){
        return initalHealthAmount;
    }
}
