using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dollar : MonoBehaviour
{

    VendMachineScript vendScript;

    public AudioClip dollarSound;
    public AudioClip angerSound;

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
            
            Destroy(gameObject);
        }

        vendScript.vendingAudio.PlayOneShot(dollarSound, 1.0f);

        StartCoroutine(BigThink());
    }

    IEnumerator BigThink()
    {
        yield return new WaitForSeconds(3);
        vendScript.vendingAudio.PlayOneShot(angerSound, 1.0f);
    }
}
