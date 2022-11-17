using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorLook : MonoBehaviour
{
    [Range(50, 500)]
    public float sens;

    public Transform body;

    float xRot = 0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        #region Camera Movement
        float rotX = Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;

        xRot -= rotY;
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        xRot = Mathf.Clamp(xRot, -90, 90f);

        #endregion

    }

}
