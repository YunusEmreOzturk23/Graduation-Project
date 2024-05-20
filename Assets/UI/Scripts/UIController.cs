using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bulletText;
    [SerializeField]
    private TextMeshProUGUI hpText;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Swat");
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = player.gameObject.GetComponent<GunClampingSystem>().GetGunMagazine().ToString() + "/" +
            player.gameObject.GetComponent<GunClampingSystem>().GetAmmunition().ToString();
        hpText.text = "HP: " + player.GetComponent<CharacterController>().getHP();
    }
}
