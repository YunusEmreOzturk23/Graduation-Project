using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunClampingSystem : MonoBehaviour
{
    Camera camera;
    [SerializeField]
    LayerMask zombieLayer;
    // Start is called before the first frame update
    CharacterController hpController;
    Animator anim;
    [SerializeField]
    private ParticleSystem muzzleFlash;
    void Start()
    {
        camera = Camera.main;
        hpController = this.gameObject.GetComponent<CharacterController>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpController.getIsLife()==true)
        {
            if (Input.GetMouseButton(0))
            {
                anim.SetBool("shoot", true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("shoot", false);
            }
        }
        
    }
    public void Shoot()
    {
        muzzleFlash.Play();
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, zombieLayer))
        {
            hit.collider.gameObject.GetComponent<ZombieController>().TakeDamage();
        }
    }
}
