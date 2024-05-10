using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunClampingSystem : MonoBehaviour
{
    Camera camera;
    [SerializeField]
    LayerMask zombieLayer;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        
    }
    void Shoot()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, zombieLayer))
        {
            hit.collider.gameObject.GetComponent<ZombieController>().TakeDamage();
        }
    }
}
