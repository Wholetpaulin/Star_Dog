using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float speed = 13f;
    [Tooltip("In m")] [SerializeField] float xRange = 7.25f;

    void Start () {
		
	}
	
	void Update () {
        ProcessTranslation();
        ProcessRotation();      // Lets get the ship to rotate sidewys
	}

    private void ProcessTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // This is slowly moving away from +/- 1
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical"); // This is slowly moving away from +/- 1
        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(Mathf.Clamp(rawXPos, -xRange, xRange), Mathf.Clamp(rawYPos, -5f, 4.5f), transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(90f, 0f, 0f); // in our case x is pitch y is yaw z is roll
    }
}
