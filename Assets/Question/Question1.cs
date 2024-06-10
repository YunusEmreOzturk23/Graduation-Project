using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Question1 : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI questionText;
    [SerializeField]
    private Button answer1Button;
    [SerializeField]
    private Button answer2Button;

    private Text button1Text;
    private Text button2Text;

    private GameObject targetPlayer;
    private bool isAnswered = false;

    void Start()
    {
        button1Text = answer1Button.GetComponentInChildren<Text>();
        button2Text = answer2Button.GetComponentInChildren<Text>();

        answer1Button.onClick.AddListener(OnAnswer1ButtonClick);
        answer2Button.onClick.AddListener(OnAnswer2ButtonClick);

        targetPlayer = GameObject.Find("Swat");

        questionText.gameObject.SetActive(false);
        answer1Button.gameObject.SetActive(false);
        answer2Button.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("swat") && !isAnswered)
        {
            questionText.gameObject.SetActive(true);
            answer1Button.gameObject.SetActive(true);
            answer2Button.gameObject.SetActive(true);

            questionText.text = "Fatih Sultan Mehmet’in babasý kimdir?";
            button1Text.text = "2. Murat";
            button2Text.text = "Yýldýrým Bayezid";

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            targetPlayer.GetComponent<GunClampingSystem>().SetCanShoot(false);
            Camera.main.GetComponent<CameraController>().SetCanControlCamera(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("swat") && !isAnswered)
        {
            HideUI();
        }
    }

    public void OnAnswer1ButtonClick()
    {
        if (isAnswered) return;

        isAnswered = true;
        SetButtonColor(answer1Button, Color.green);

        targetPlayer.GetComponent<CharacterController>().IncreaseHP();
        targetPlayer.GetComponent<GunClampingSystem>().IncreaseAmmunition();

        StartCoroutine(CloseQuestion());
    }

    public void OnAnswer2ButtonClick()
    {
        if (isAnswered) return;

        isAnswered = true;
        SetButtonColor(answer2Button, Color.red);

        StartCoroutine(CloseQuestion());
    }

    private IEnumerator CloseQuestion()
    {
        yield return new WaitForSeconds(2);

        HideUI();
    }

    private void HideUI()
    {
        questionText.gameObject.SetActive(false);
        answer1Button.gameObject.SetActive(false);
        answer2Button.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        targetPlayer.GetComponent<GunClampingSystem>().SetCanShoot(true);
        Camera.main.GetComponent<CameraController>().SetCanControlCamera(true);
    }

    private void SetButtonColor(Button button, Color color)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = color;
        colors.selectedColor = color;
        button.colors = colors;
    }
}
