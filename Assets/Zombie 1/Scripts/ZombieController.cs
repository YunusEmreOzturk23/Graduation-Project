using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    [SerializeField]
    float zombieHP = 100;
    Animator zombieAnim;
    GameObject targetPlayer;
    [SerializeField]
    float chasingDistance;
    [SerializeField]
    float attackDistance;
    NavMeshAgent zombieNavMesh;
    // Start is called before the first frame update
    void Start()
    {
        zombieAnim = this.gameObject.GetComponent<Animator>();
        targetPlayer = GameObject.Find("Swat");
        zombieNavMesh = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (zombieHP <= 0)
        {
            zombieAnim.SetBool("died", true);
            StartCoroutine(DestroyZombie());
        }
        else
        {
            float distance = Vector3.Distance(this.gameObject.transform.position, targetPlayer.transform.position);
            if (distance < chasingDistance)
            {
                zombieNavMesh.isStopped = false;
                zombieNavMesh.SetDestination(targetPlayer.transform.position);
                zombieAnim.SetBool("walking", true);
                zombieAnim.SetBool("punching", false);
                this.transform.LookAt(targetPlayer.transform.position);
            }
            else
            {
                zombieNavMesh.isStopped = true;
                zombieAnim.SetBool("walking", false);
                zombieAnim.SetBool("punching", false);
            }
            if (distance < attackDistance)
            {
                this.transform.LookAt(targetPlayer.transform.position);
                zombieNavMesh.isStopped = true;
                zombieAnim.SetBool("walking", false);
                zombieAnim.SetBool("punching", true);
            }
        }
    }
    public void DoDamage()
    {
       // targetPlayer.GetComponent<CharacterController>().TakeDamage();
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
