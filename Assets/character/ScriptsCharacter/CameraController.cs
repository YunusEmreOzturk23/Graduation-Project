using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    Vector3 offset;//target -camere distance
    float mouseX;
    float mouseY;
    [SerializeField]
    float mouseSensivity;//fare hassasiyeti -tr
    Vector3 objrot;
    [SerializeField]
    Transform characterBody;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//kamerayý ekrana kilitleme
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.position + offset, Time.deltaTime * 10);
        mouseX+= Input.GetAxis("Mouse X")*mouseSensivity;
        mouseY+= Input.GetAxis("Mouse Y")*mouseSensivity;
        if (mouseY >= 25)
        {
            mouseY = 25;
        }
        if(mouseY<=-40){
            mouseY = -40;
        }
        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
        target.transform.eulerAngles = new Vector3(0, mouseX, 0);
        //karakter asaðý yukarý eðilme
        Vector3 temp = this.transform.localEulerAngles;
        temp.z = 0;
        temp.y = this.transform.localEulerAngles.y;
        temp.x = this.transform.localEulerAngles.x + 10;
        objrot = temp;
        characterBody.transform.eulerAngles = objrot;
    }
}
