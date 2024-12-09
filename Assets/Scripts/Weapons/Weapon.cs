using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    VendMachineScript vendMachineScript;

    public int maxHealth;
    public int currentHealth;

    [Header("ParticleSystems")]
    public ParticleSystem vendHitParticles;
    public ParticleSystem healParticles;
    public ParticleSystem compHitParticles;
    public ParticleSystem mouseHitParticles;
    public ParticleSystem keyboardHitParticles;
    public ParticleSystem swordHitParticles;
    public ParticleSystem mugHitParticles;
    public ParticleSystem lampHitParticles;

    void Start()
    {
        currentHealth = maxHealth;
    }
    
    void Update()
    {
        if (currentHealth <= 0)
        {
            //if (gameObject.tag == )
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Machine")
        {
            vendMachineScript = other.gameObject.GetComponent<VendMachineScript>();

            TakeDamage(1);
        }

        if (gameObject.tag == "Weapon")
        {
            vendHitParticles.Play();

            vendMachineScript.TakeDamage(1);

            vendMachineScript.vendingAudio.PlayOneShot(vendMachineScript.hitSound, 1.0f);
        }

        if (gameObject.tag == "ComputerWPN")
        {
            // for the other ones probably make other vendhits and name them after each weapon. then make other sound effects and have hp and breaking for each
            compHitParticles.Play();

            vendMachineScript.TakeDamage(1);

            // like a fridge explosion or sm
            vendMachineScript.vendingAudio.PlayOneShot(vendMachineScript.bigHitSound, 0.3f);
        }

        if (gameObject.tag == "MouseWPN")
        {
            // for the other ones probably make other vendhits and name them after each weapon. then make other sound effects and have hp and breaking for each
            mouseHitParticles.Play();

            vendMachineScript.TakeDamage(1);

            // melee soft hit
            vendMachineScript.vendingAudio.PlayOneShot(vendMachineScript.softHitSound, 2f);
        }

        if (gameObject.tag == "KeyboardWPN")
        {
            // for the other ones probably make other vendhits and name them after each weapon. then make other sound effects and have hp and breaking for each
            keyboardHitParticles.Play();

            vendMachineScript.TakeDamage(1);

            // lego breaking
            vendMachineScript.vendingAudio.PlayOneShot(vendMachineScript.legoSound, 0.7f);
        }

        if (gameObject.tag == "SwordWPN")
        {
            // for the other ones probably make other vendhits and name them after each weapon. then make other sound effects and have hp and breaking for each
            swordHitParticles.Play();

            vendMachineScript.TakeDamage(1);

            // marth slash
            vendMachineScript.vendingAudio.PlayOneShot(vendMachineScript.slashSound, 1f);
        }

        if (gameObject.tag == "MugWPN")
        {
            // for the other ones probably make other vendhits and name them after each weapon. then make other sound effects and have hp and breaking for each
            mugHitParticles.Play();

            vendMachineScript.TakeDamage(1);

            // glass breaking
            vendMachineScript.vendingAudio.PlayOneShot(vendMachineScript.mugSound, 0.2f);
        }

        if (gameObject.tag == "LampWPN")
        {
            // for the other ones probably make other vendhits and name them after each weapon. then make other sound effects and have hp and breaking for each
            lampHitParticles.Play();

            vendMachineScript.TakeDamage(1);

            // metal pipe sfx
            vendMachineScript.vendingAudio.PlayOneShot(vendMachineScript.pipeSound, 0.12f);
        }

        if (gameObject.tag == "PencilHolderWPN")
        {
            vendHitParticles.Play();

            vendMachineScript.TakeDamage(1);

            vendMachineScript.vendingAudio.PlayOneShot(vendMachineScript.hitSound, 1.0f);
        }

        if (gameObject.tag == "TF2Wrench")
        {
            healParticles.Play();
            
            vendMachineScript.vendingAudio.PlayOneShot(vendMachineScript.fixSound, 0.3f);

            vendMachineScript.Heal(1);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }
}
