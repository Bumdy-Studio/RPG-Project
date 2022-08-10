using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraMovement : MonoBehaviour {

    private Vector3 previousMouseLocation;

    [Header("Movement")]
    [SerializeField] private string _verticalAxisName = "Vertical";
    [SerializeField] private string _horizontalAxisName = "Horizontal";
    [SerializeField] private float _moveSpeed = 10f;
    
    [Header("Rotation")]
    [SerializeField] private float _lookXMultiplier = 2.5f;
    [SerializeField] private float _lookYMultiplier = 2f;
    [SerializeField] private float _xLookCap = 80;
    [SerializeField] private float _xLookMin = -270;

    void Start() {
        previousMouseLocation = Input.mousePosition;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
   
    void Update() {
        
        //
        // Move camera
        //
        float moveX = Input.GetAxis(_horizontalAxisName);
        float moveY = Input.GetAxis(_verticalAxisName);

        //Apply speed multiplier and delta time
        moveX *= Time.deltaTime * _moveSpeed;
        moveY *= Time.deltaTime * _moveSpeed;

        Vector3 pos = transform.position;
        Vector3 newPos = pos + (transform.right * moveX)+ (transform.forward * moveY);
        
        transform.position = Vector3.Slerp(pos, newPos, _moveSpeed * Time.deltaTime);
        
        //
        // Rotate camera
        //

        float rotateX = -Input.GetAxis("Mouse Y") * _lookXMultiplier * Time.deltaTime;
        float rotateY = Input.GetAxis("Mouse X") * _lookYMultiplier * Time.deltaTime;

        rotateX = Mathf.Clamp(rotateX, _xLookMin, _xLookCap);

        transform.localEulerAngles += new Vector3(rotateX, rotateY, 0) * Time.deltaTime * 100;

        previousMouseLocation = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
        
        //Allow exiting
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = !Cursor.visible;

            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}
