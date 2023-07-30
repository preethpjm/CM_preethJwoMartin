using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float currentHealthSlow;
    public int coinsCollected = 0;
    [SerializeField] Image healthBar;
    [SerializeField] Image scoreBar;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float moveSpeed;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject loosePanel;

    private void Start()
    {
        healthBar.fillAmount = 100;
        scoreBar.fillAmount = 0;
        currentHealth = maxHealth;
        currentHealthSlow = maxHealth;
        winPanel.SetActive(false);
        loosePanel.SetActive(false);
    }

    private void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(movement * Time.deltaTime * moveSpeed);
    }

    public void CollectCoin(int coinValue)
    {
        float t = 0;
        coinsCollected += coinValue;
        float fillAmount = (float)coinsCollected / (float)CoinSpawner.numberOfCoins;
        t += Time.deltaTime / 1f;
        scoreBar.fillAmount = fillAmount;
        if(coinsCollected >= CoinSpawner.numberOfCoins)
        {
            SfxManager._insatnce.Play_WinSound();
            winPanel.SetActive(true);
        }

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        float fillAmount = (float)currentHealth / (float)maxHealth;
        healthBar.fillAmount = fillAmount;

        if (currentHealth <= 0)
        {
            SfxManager._insatnce.Play_LooseSound();
            loosePanel.SetActive(true);
        }
    }
}