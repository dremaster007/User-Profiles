using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Controller
{
    public static GameObject obesrvedObject = null;
    private float moveVertical = 0f, moveHorizontal = 0f;
    private int internCoeffX = 1000;
    private int internCoeffY = 750;
    private float minimumY = -70f;
    private float maximumY = 70f;

    private void Start()
    {
        moveHorizontal = 0f;
        moveVertical = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Get object in camera sight
        obesrvedObject = RayCastManager.GetRayCastedObjectToCamera();

        //Test
        if (obesrvedObject != null)
        {
            Debug.Log(obesrvedObject.name);
        }

        //Mouse camera movement
        #region Mouse camera movement
        if (!GameManager.isGamePaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (GameManager.playerCanControlCamera)
            {
                moveHorizontal += InputManager.MouseX() * internCoeffX * Time.deltaTime;
                moveVertical += InputManager.MouseY() * internCoeffY * Time.deltaTime;
                moveVertical = Mathf.Clamp(moveVertical, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-moveVertical, moveHorizontal, 0f);
            }
        }
        #endregion
    }
}
