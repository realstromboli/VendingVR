using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendMachineScript : MonoBehaviour
{

    [Header("Variables")]
    public int maxHealth = 21;
    public int currentHealth;
    public AudioClip hitSound;
    public AudioSource vendingAudio;

    void Start()
    {
        currentHealth = maxHealth;
        vendingAudio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        //trigger hurt animations
        vendingAudio.PlayOneShot(hitSound, 1.0f);

        if (currentHealth <= 14)
        {
            //set texture to damaged 1
        }

        if (currentHealth <= 7)
        {
            //set texture to damaged 2
        }

        //this is assuming there will be pristine, damaged, and heavily damaged textures for the machine

        if (currentHealth <= 0)
        {
            //you have killed vending machine
            //explosion sfx (and pfx?)
            //game end, reset?
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Weapon")
    //    {
    //        vendingAudio.PlayOneShot(hitSound, 1.0f);
    //        TakeDamage(1);
    //    }

    //    if (other.tag == "TF2Wrench")
    //    {
    //        //vendingAudio.PlayOneShot(fixSound, 1.0f);
    //        Heal(1);
    //    }
    //}
}
