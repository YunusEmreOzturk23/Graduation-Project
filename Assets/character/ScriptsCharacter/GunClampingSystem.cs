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
    private float gunMagazine=100;// þarjör TR
    private float ammunition = 450;//cephane -TR
    private float magazineCapasity=100;
    private bool canShoot = true; // Ateþ etme durumu

    AudioSource voiceSource;
    

    public AudioClip fireVoice;
    public AudioClip reloadVoice;

    void Start()
    {
        camera = Camera.main;
        hpController = this.gameObject.GetComponent<CharacterController>();
        anim = this.gameObject.GetComponent<Animator>();
        voiceSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpController.getIsLife()==true && canShoot)
        {
            if (Input.GetMouseButton(0))
            {
                if (gunMagazine > 0)
                {
                    anim.SetBool("shoot", true);
                }
                if (gunMagazine <= 0)
                {
                    anim.SetBool("shoot", false);
                }
                if (gunMagazine <= 0 && ammunition>0)
                {
                    anim.SetBool("changeMagazine", true);
                    
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("shoot", false);
            }
        }
    }
    public void SetCanShoot(bool value)
    {
        canShoot = value;
    }
    public void MagazineReolading()
    {
        voiceSource.PlayOneShot(reloadVoice);
        ammunition -= magazineCapasity - gunMagazine;
        gunMagazine = magazineCapasity;
        anim.SetBool("changeMagazine", false);
    }
    public void Shoot()
    {
        if (gunMagazine>0)
        {
            muzzleFlash.Play();
            if (voiceSource == null)
            {
                Debug.LogError("Voice source is not assigned.");
                return;
            }

            if (fireVoice == null)
            {
                Debug.LogError("Fire voice clip is not assigned.");
                return;
            }
            voiceSource.PlayOneShot(fireVoice);
            Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, zombieLayer))
            {
                hit.collider.gameObject.GetComponent<ZombieController>().TakeDamage();
            }
            gunMagazine--;
        }
       
    }
    public float GetGunMagazine()
    {
        return gunMagazine;
    }
    public float GetAmmunition()
    {
        return ammunition;
    }
    public void IncreaseAmmunition()
    {
        ammunition += 350;
    }
}
