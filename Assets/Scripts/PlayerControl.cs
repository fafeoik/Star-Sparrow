using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{
    [Header("General")]

    [Tooltip("м/c")] [SerializeField] float Speed = 45f;

    [SerializeField] float XClapm = 25f;
    [SerializeField] float YClapm = 15f;
    [SerializeField] GameObject[] guns;

    [Header("Rotation")]
    [SerializeField] float xRotFactor = -1.4f;
    [SerializeField] float yRotFactor = 1.5f;
    [SerializeField] float zRotFactor = 1f;

    [Header("RotationOnMove")] 
    [SerializeField] float xMoveRot = -15f;
    [SerializeField] float yMoveRot = 15f;
    [SerializeField] float zMoveRot = -15f;

    bool isControlEnabled = true;

    float xMove, yMove;


    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            MoveShip();
            RotateShip();
            FireGuns();
        }
    }

    void OnPlayerDeath()
    {
        isControlEnabled = false;   
    }
    void MoveShip()
    {
        xMove = CrossPlatformInputManager.GetAxis("Horizontal");
        yMove = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xMove * Speed * Time.deltaTime;
        float yOffset = yMove * Speed * Time.deltaTime;

        float newXPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(newXPos, -XClapm, XClapm);

        float newYPos = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(newYPos, -YClapm, YClapm);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }
    void RotateShip()
    {
        float xRot = transform.localPosition.y * xRotFactor + yMove * xMoveRot;
        float yRot = transform.localPosition.x * yRotFactor + xMove * yMoveRot;
        float zRot = xMove * zMoveRot;



        transform.localRotation = Quaternion.Euler(xRot, yRot, zRot);
    }
    void FireGuns()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            ActiveGuns();
        }
        else
        {
            DeactiveGuns();
        }
    }
    void ActiveGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }
    void DeactiveGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }
}
