using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public static CharacterData Instance;

    public float hp;
   

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Bu nesneyi yeni sahnelere taþý
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
