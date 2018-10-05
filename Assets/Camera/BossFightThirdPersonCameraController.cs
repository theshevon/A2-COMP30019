﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: SQUIDWARDS CONTROLLER MUST TURN ALONG WITH CAMERA

public class BossFightThirdPersonCameraController : MonoBehaviour {

    public bool lockCursor;
    public Transform target;
    public Transform rotationTarget;
    public float mouseSensitivity = 10;
    public float distanceFromTarget = 2;
    public float pitchMin = -40;
    public float pitchMax = 80;

    float pitch;
    float yaw;

    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    void Start () {
        //if (lockCursor)
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //}
    }
    
    void LateUpdate () {

        // get yaw and pitch based on mouse movement
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        // ensure that the camera doesn't tumble over the player
        // or goes below ground
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        //currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        //transform.eulerAngles = currentRotation;

        transform.LookAt(rotationTarget.transform, Vector3.up);
        transform.Rotate(Vector3.up * -5);
        
      
        transform.position = target.position - rotationTarget.position- transform.forward * distanceFromTarget;
	}
    
}
