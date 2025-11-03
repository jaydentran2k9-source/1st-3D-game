using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;

    [SerializeField] Player_Movement playerMovement;
    [SerializeField] TextMeshProUGUI healthText;
    


    public float damagePerTick = 5f; // damage applied every tick
    public float tick = 1f; // damage applied every one second
    public float damageDuration = 5; // how long it lasts for


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        if (healthAmount <= 0)
        {
            Debug.Log("Player is Dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (healthAmount < 100)
        {
            heal(1);
        }
    }



    public void TakeDamage(float damage)
    {
        StartCoroutine(DamageOvertime(damage));
        //healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    private IEnumerator DamageOvertime(float damage)
    {
        float endTime = Time.time + damageDuration;
        damagePerTick = damage / damageDuration;
        while (Time.time < endTime)
        {
            healthAmount -= damagePerTick;
            healthBar.fillAmount = healthAmount / 100f;
            yield return new WaitForSeconds(tick);
        }
    }



    public void heal(float healAmount)
    {
        healthAmount += healAmount * Time.deltaTime;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
