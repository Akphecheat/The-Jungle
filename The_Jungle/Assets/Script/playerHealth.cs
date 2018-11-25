using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    public float fullHealth;
    float currentHealth;
    public GameObject deathFX;
    PlayerController controllerMovement;
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
        currentHealth = fullHealth;

        controllerMovement = GetComponent<PlayerController>();
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
