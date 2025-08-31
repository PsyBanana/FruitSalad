using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 100f;

    public float xRotation = 0f;
    public float minxRotation = -60f;
    public float maxXRotation = 60f;

    void Start()
    {
        this.transform.position = playerBody.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minxRotation, maxXRotation);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // rotatia camerei pe verticala
        playerBody.Rotate(Vector3.up * mouseX); // rotatia personajului pe orizontala

    }
}
