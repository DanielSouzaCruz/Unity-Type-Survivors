using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    // Start is called before the first frame update

    public float currentHealth, maxHealth;


    public static PlayerHealthController instance;

    private void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
