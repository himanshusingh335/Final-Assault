using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RocketBehaviour : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 7f;
    [Tooltip("In m")] [SerializeField] float xRange = 5.5f;
    [Tooltip("In m")] [SerializeField] float yRange = 3f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;

    [SerializeField] float positionYawFactor = +5f;

    [SerializeField] float controlRollFactor = -5f;

    float xThrow;
    float yThrow;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        Translation();
        Rotation();
    }

    private void Rotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float role = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, role) ;
    }

    private void Translation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Speed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, +xRange);

        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Speed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedXPosV = Mathf.Clamp(rawNewYPos, -yRange, +yRange);

        transform.localPosition = new Vector3(transform.localPosition.x, clampedXPosV, transform.localPosition.z);
    }
}
