using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    float characterSpeed;
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");//yatay
        float vertical = Input.GetAxis("Vertical");//dikey
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        gameObject.transform.Translate(horizontal * characterSpeed * Time.deltaTime, 0, vertical * characterSpeed * Time.deltaTime);
    }
}
