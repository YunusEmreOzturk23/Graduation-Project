using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager'ý kullanmak için gerekli

public class LoginController : MonoBehaviour
{
    // Bu fonksiyon sahne geçiþini gerçekleþtirir
    public void LoadScene1()
    {
        SceneManager.LoadScene("Scene1");
    }
}
