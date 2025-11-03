using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StaminaManager : MonoBehaviour
{
    public static StaminaManager instance;

    public Image staminaBar;
    public float staminaAmount,staminaLeft = 100f;
    public bool isRegain;
    float regainAmount = 10f;

    public float amplifier = 2;
    


    [SerializeField] Player_Movement playerMovement;
    [SerializeField] TextMeshProUGUI staminaText;


    public void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Regain(10)); // Delays for 2 seconds

        if (Input.GetKeyDown(KeyCode.LeftShift) && staminaAmount >= 20)
        {
            UseStamina(10);
        }
        if (staminaAmount < 0)
        {
          //  staminaAmount = 0;
            
            if(staminaAmount <= 0 && isRegain == false)
            {
                isRegain = true;
               // StartCoroutine(Regain(10)); // Delays for 2 seconds

            }

            
        }

        if (staminaText != null)
        {
            
            staminaText.text = "Stamina: " + staminaAmount.ToString() + " / " + staminaLeft.ToString();

        }
    }

    public void UseStamina(float Stamina)
    {
        staminaAmount -= Stamina;
        staminaBar.fillAmount = staminaAmount / 100f;
    }




    IEnumerator Regain(int v)
    {

       
        
        while (staminaAmount < 100f && !Input.GetKey(KeyCode.LeftShift))
        {
           // yield return null; // Wait for the next frame
            print("isresting");
            staminaAmount += regainAmount * Time.deltaTime;
            staminaBar.fillAmount = staminaAmount / 100f;
            yield return new WaitForSeconds(2f);
        }


        print("done resting");
        staminaAmount = Mathf.Clamp(staminaAmount, 0f, 100f);
        isRegain = false;
    }
    


}
