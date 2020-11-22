using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerRoot;

    float xrotation = 0f;

    bool isGrounded;

    TaskManager manager;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        manager = FindObjectOfType<TaskManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.isIntask)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;

        if (manager.isIntask)
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        playerRoot.Rotate(Vector3.up * mouseX);



    }


}
