using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("General Setup Setting")]
    [Tooltip("how fast ship moves up and down based upon player input")]
    [SerializeField] float controlSpeed = 10f;
    [Tooltip("how far player move horizontally")] [SerializeField] float xRange = 5f;
    [Tooltip("how far player move vertically")] [SerializeField] float yRange = 5f;
    [Header("Laser Gun Array")]
    [Tooltip("add all player lasers")]
    [SerializeField] GameObject[] lasers;
    [Header("Screen Position based turning")]
    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float controlPitchFactor = 10f;
    [Header("Player Input based turning")]
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = 30f;
    float xThrow, yThrow;
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        processFiring();
    }
    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

     void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawxPOS = transform.localPosition.x + xOffset;
        float clampedxPOS = Mathf.Clamp(rawxPOS, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawyPOS = transform.localPosition.y + yOffset;
        float clampedyPOS = Mathf.Clamp(rawyPOS, -yRange, yRange);

        transform.localPosition = new Vector3(clampedxPOS, clampedyPOS, transform.localPosition.z);
    }
    void processFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetActiveLasers(true);
        }
        else
        {
            SetActiveLasers(false);
        }
    }
    void SetActiveLasers(bool isActive)
    {
        foreach (GameObject Tutruong in lasers)
        {
            var emissionModule = Tutruong.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}