using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    public string mouseXInputName, mouseYInputName;
    public float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    private float xAxisClamp;

    private void Awake()
    {
        lockCursor();
        xAxisClamp = 0.0f;
    }

    private void lockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        CameraRotation();
	}

    private void CameraRotation()
    {
        float mouseX = Input.GetAxisRaw(mouseXInputName) * mouseSensitivity;
        float mouseY = Input.GetAxisRaw(mouseYInputName) * mouseSensitivity;

        xAxisClamp += mouseY;

        // Making sure that camera wont rotate over 90 degree.
        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseX = 0.0f ;
            ClampXAxisRoationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseX = 0.0f;
            ClampXAxisRoationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // Makes sure that camera wont go over clamp values
    private void ClampXAxisRoationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
