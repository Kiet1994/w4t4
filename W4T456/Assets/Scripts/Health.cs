using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]// chú thích ? ph?n Inpector
    private float startingHealth = 10; //hp start
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead; 
    private float x;
    private float y;
    private bool h;

    [Header("iFrames")] //?
    [SerializeField] private float iFramesDuration; // th?i gian b?t t?
    [SerializeField] private int numberOfFlashes; // th?i gian nhân v?t màu ??
    private SpriteRenderer spriteRend; //thay ??i màu sang b?t t? cho nhân v?t
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>(); //?
        

    }
    public void TakeDamage(float _damage) // Nh?n  sát th??ng
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth); // Tr? v? giá tr? ?ã cho trong ph?m vi, min, max
        //currentHealth -= _damage;
        if (currentHealth > 0)
        {
            //anim.SetTrigger("hurt");
            StartCoroutine(Invunerability()); //Th?c hi?n câu l?nh Invunerability ? d??i
        }
        else
        {
            if (!dead)  //T thì th?c hi?n F thì không th?c hi?n
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false; // player không di chuy?n khi ch?t.  
                GetComponent<PlayerAttack>().enabled = false;
                dead = true;
            }
        }
        Debug.Log(currentHealth);
    }
    public void AddHealth(float _value) // thêm máu
    {
        //currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        anim.SetTrigger("health");
        h = true;
        y = _value;
    }
    private void Update()
    {
        if (h == true)
        {
            x += 0.01f;
            if (x < y)
            {
                currentHealth = Mathf.Clamp(currentHealth + 0.01f, 0, startingHealth);
            }
            else
            {
                x = 0;
                h = false;
            }
        }
        Debug.Log(currentHealth);
    }
    private IEnumerator Invunerability() // B? th??ng ??i màu ??ng th?i b?t t? trong th?i gian ?ó
    {
        Physics2D.IgnoreLayerCollision(10, 11, true); // b? qua va ch?m gi?a 2 l?p 10, 11 (player and enemy)
        for (int i = 0; i < numberOfFlashes; i++) // l?p i = 0, i s? nguyên nên l?p l?i 1 l?n n?u numberOfFlashes là 1
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f); //??i màu ??
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2)); // th?i gian duy trì 1s
            spriteRend.color = Color.white; //??i màu tr?ng
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2)); // th?i gian duy trì 1s
        }
        //invunerabity du?tion
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
