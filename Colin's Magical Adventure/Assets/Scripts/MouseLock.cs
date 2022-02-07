using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float xRotation = 0f;

    public float maxFov = 90f;
    public float minFov = 15f;
    public float fovSensitivity = 15f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("SheetOpen") == 0 && PlayerPrefs.GetInt("IsDead") == 0 && PlayerPrefs.GetInt("Victory") == 0)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * fovSensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;
            if(PlayerPrefs.GetInt("View") == 2)
            {
                transform.localRotation = Quaternion.Euler(xRotation, 180f, 0f);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            }
            playerBody.Rotate(Vector3.up * mouseX);
        }

    }
}
