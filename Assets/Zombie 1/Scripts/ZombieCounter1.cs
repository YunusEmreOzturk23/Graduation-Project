using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieCounter1 : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI stateText;
    private void Start()
    {
        stateText.gameObject.SetActive(false);
    }
    void Update()
    {
        int zombieCount = CountZombies();
        Debug.Log("Number of zombies in the scene: " + zombieCount);

        if (zombieCount == 0)
        {
            stateText.gameObject.SetActive(true);
            LoadScene("Scene2");
        }
    }

    int CountZombies()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombie");
        return zombies.Length;
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

