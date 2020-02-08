using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraView : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float xRotation = 0f;
    public bool invertRotation = false;

    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Capture mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Mouse look up and down (+ is inverted, - is normal)
        xRotation = invertRotation ? xRotation += mouseY : xRotation -= mouseY;
        // Clamp rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        // Mouse look up and down transformation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Mouse look right and left
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
