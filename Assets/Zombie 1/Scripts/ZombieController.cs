using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField]
    float zombieHP = 100;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieHP <= 0)
        {
            animator.SetBool("died", true);
            StartCoroutine(DestroyZombie());
        }
        else
        {
            //kodlanacak
        }
    }
    IEnumerator DestroyZombie()
    {
        yield return new WaitForSeconds(8);
        Destroy(this.gameObject);
    }
    public void TakeDamage()
    {
        zombieHP -= Random.Range(15, 20);
    }
}
