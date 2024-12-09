using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    VendMachineScript vendMachineScript;
    public ParticleSystem vendHitParticles;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Machine")
        {
            vendMachineScript = other.gameObject.GetComponent<VendMachineScript>();

            vendHitParticles.Play();

            vendMachineScript.TakeDamage(1);

            if (vendMachineScript.currentHealth == 1)
            {
                //hitAudio.PlayOneShot(boomSound, 1.0f);
            }
        }

        //save for other weapon types, put on seperate script

        //if (other.tag == "TF2Wrench")
        //{
        //    //vendingAudio.PlayOneShot(fixSound, 1.0f);
        //    vendMachineScript.Heal(1);
        //}
    }
}
