using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendMachineScript : MonoBehaviour
{

    [Header("Variables")]
    public int maxHealth = 30;
    public int currentHealth;
    
    public AudioSource vendingAudio;
    public GameObject vendingMachine;
    public GameObject helpScreen;
    public ParticleSystem vendBlastParticles;
    public float flinchDuration = 0.3f;

    public Animator vendAnimator;
    public string[] animations;

    public Material pristine;
    public Material damaged1;
    public Material damaged2;
    public Material damaged3;
    public Material flinch1;
    public Material flinch2;
    public Material flinch3;
    public Material flinch4;
    public Material currentIdle;
    public Material currentFlinch;

    [Header("SFX")]
    public AudioClip hitSound;
    public AudioClip dollarSound;
    public AudioClip angerSound;
    public AudioClip fixSound;
    public AudioClip bigHitSound;
    public AudioClip softHitSound;
    public AudioClip legoSound;
    public AudioClip slashSound;
    public AudioClip mugSound;
    public AudioClip pipeSound;

    [SerializeField] public VendHPBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        vendingAudio = GetComponent<AudioSource>();
        vendingMachine.GetComponent<MeshRenderer>().material = pristine;
        currentFlinch = flinch1;
        currentIdle = pristine;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        vendAnimator = GetComponent<Animator>();
    }

    private void Awake()
    {
        healthBar = GetComponentInChildren<VendHPBar>();
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
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        vendAnimator.SetInteger("AnimIndex", Random.Range(0, 3));
        vendAnimator.SetTrigger("HitTrigger");
        vendingMachine.GetComponent<MeshRenderer>().material = currentFlinch;
        StartCoroutine(Flinch());

        if (currentHealth <= 30)
        {
            currentIdle = pristine;
            currentFlinch = flinch1;
        }

        if (currentHealth <= 20)
        {
            currentIdle = damaged1;
            currentFlinch = flinch2;
        }

        if (currentHealth <= 13)
        {
            currentIdle = damaged2;
            currentFlinch = flinch3;
        }

        if (currentHealth <= 6)
        {
            currentIdle = damaged3;
            currentFlinch = flinch4;
        }

        //this is assuming there will be pristine, damaged, and heavily damaged textures for the machine

        if (currentHealth <= 0)
        {
            //you have killed vending machine
            //explosion sfx (and pfx?)
            vendBlastParticles.Play();
            //game end, reset? something something game manager set active win screen
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth >= 6)
        {
            currentIdle = damaged3;
            currentFlinch = flinch4;
            vendingMachine.GetComponent<MeshRenderer>().material = currentIdle;
        }

        if (currentHealth >= 13)
        {
            currentIdle = damaged2;
            currentFlinch = flinch3;
            vendingMachine.GetComponent<MeshRenderer>().material = currentIdle;
        }

        if (currentHealth >= 20)
        {
            currentIdle = damaged1;
            currentFlinch = flinch2;
            vendingMachine.GetComponent<MeshRenderer>().material = currentIdle;
        }

        if (currentHealth >= 29)
        {
            currentIdle = pristine;
            currentFlinch = flinch1;
            vendingMachine.GetComponent<MeshRenderer>().material = currentIdle;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    IEnumerator Flinch()
    {
        yield return new WaitForSeconds(flinchDuration);
        vendingMachine.GetComponent<MeshRenderer>().material = currentIdle;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dollar")
        {

            Destroy(other.gameObject);

            vendingAudio.PlayOneShot(dollarSound, 0.8f);

            StartCoroutine(BigThink());
        }
    }

    IEnumerator BigThink()
    {
        yield return new WaitForSeconds(3);
        vendingAudio.PlayOneShot(angerSound, 0.8f);
        yield return new WaitForSeconds(1);
        helpScreen.gameObject.SetActive(true);
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
