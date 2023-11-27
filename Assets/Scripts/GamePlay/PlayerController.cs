using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float currentHealthSlow;
    public int coinsCollected = 0;

    [SerializeField] Image healthBar;
    [SerializeField] Image scoreBar;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float moveSpeed;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject loosePanel;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private float maxMoveDelta;
    [SerializeField] private Material collectMaterial, damageMaterial;

    private Rigidbody rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthBar.fillAmount = 100;
        scoreBar.fillAmount = 0;
        currentHealth = maxHealth;
        currentHealthSlow = maxHealth;
        winPanel.SetActive(false);
        loosePanel.SetActive(false);
    }

    private void Update()
    {

        float speed = rb.velocity.magnitude;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput * Time.deltaTime, 0f, verticalInput * Time.deltaTime).normalized;
        if (movement != Vector3.zero)
        {

            rb.velocity = Vector3.ClampMagnitude(rb.velocity,moveSpeed);
            rb.velocity += movement * moveSpeed;

           

        }
        else
        {
            DeAccelerate();
        }

    }

    private void DeAccelerate()
    {
        float deacceleratevalue = Time.deltaTime * 3f;
        if (rb.velocity.magnitude > 0)
        {
            rb.velocity -= Vector3.one * deacceleratevalue;
        }
    }

    public void CollectCoin(int coinValue)
    {
       
        float t = 0;
        coinsCollected += coinValue;
        float fillAmount = (float)coinsCollected / (float)CoinSpawner.numberOfCoins;
        t += Time.deltaTime / 1f;
        scoreBar.fillAmount = fillAmount;
        
        if (transform.localScale.magnitude < 5f)
        {
            transform.localScale += new Vector3(.1f, .1f, .1f);
        }
        if (coinsCollected >= CoinSpawner.numberOfCoins)
        {
            SfxManager._insatnce.Play_WinSound();
            
            winPanel.SetActive(true);
            this.enabled = false;
        }
        
    }

    public void TakeDamage(int damageAmount)
    {
        
        currentHealth -= damageAmount;
        float fillAmount = (float)currentHealth / (float)maxHealth;
        healthBar.fillAmount = fillAmount;
        if (transform.localScale.magnitude > .1f)
        {
            transform.localScale -= new Vector3(.1f, .1f, .1f);
        }
        if (currentHealth <= 0)
        {
            SfxManager._insatnce.Play_LooseSound();
            loosePanel.SetActive(true);
            this.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectables"))
        {
            Debug.Log("Collect");
            CollectEffect();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            
            DamageEffect();
        }
    }
    public void CollectEffect()
    {
        particle.GetComponent<ParticleSystemRenderer>().material=collectMaterial;
        particle.Play();
    }
    public void DamageEffect()
    {
        particle.GetComponent<ParticleSystemRenderer>().material=damageMaterial;
        particle.Play();
    }
}