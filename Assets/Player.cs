using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float speed = 13f;
    [Tooltip("In m")] [SerializeField] float xRange = 7.25f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlPitchFactor = -14f;

    float xThrow, yThrow;

    void Start () {
		
	}
	
	void Update () {
        ProcessTranslation();
        ProcessRotation();      // Lets get the ship to rotate sidewys
	}

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // This is slowly moving away from +/- 1
        yThrow = CrossPlatformInputManager.GetAxis("Vertical"); // This is slowly moving away from +/- 1
        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(Mathf.Clamp(rawXPos, -xRange, xRange), Mathf.Clamp(rawYPos, -5f, 4.5f), transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlPitchFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); // in our case x is pitch y is yaw z is roll
    }
}
