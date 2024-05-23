using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    float characterSpeed;
    private float hp=100;
    private bool isLife;
    [SerializeField]
    TextMeshProUGUI stateText;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        isLife = true;
   
    }

    // Update is called once per frame
    void Update()
    {
        if (hp<=0)
        {
            isLife = false;
            anim.SetBool("isLife", isLife);
            stateText.gameObject.SetActive(true);
            stateText.text = "Oyunu Kaybettin";
            Time.timeScale = 0;
        }
        if (isLife==true)
        {
            Movement();
        }
   
    }
 
    public float getHP()
    {
        return hp;
    }
    public bool getIsLife()
    {
        return isLife;
    }
    public void TakeDamage()
    {
        hp -= Random.Range(5, 10);
    }
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");//yatay
        float vertical = Input.GetAxis("Vertical");//dikey
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);
        gameObject.transform.Translate(horizontal * characterSpeed * Time.deltaTime, 0, vertical * characterSpeed * Time.deltaTime);
    }
}
