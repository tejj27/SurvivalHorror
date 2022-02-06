using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update

    public float Mousesensitivity = 100f;

    public Transform PlayerBody;

    float XRotation = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        

        float MouseX = Input.GetAxis("Mouse X") * Mousesensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * Mousesensitivity * Time.deltaTime;

        XRotation -= MouseY;

        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);

        PlayerBody.Rotate(Vector3.up * MouseX);



    }
}
