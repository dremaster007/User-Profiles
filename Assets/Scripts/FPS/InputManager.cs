using UnityEngine;

public class InputManager
{
    public static float HorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    public static float VerticalAxis()
    {
        return Input.GetAxis("Vertical");
    }

    public static bool Mouse0_Btn_Down()
    {
        return Input.GetMouseButtonDown(0); // Left Click
    }

    public static bool Mouse0_Btn()
    {
        return Input.GetMouseButton(0); // Left Click Hold
    }

    public static float MouseX()
    {
        return Input.GetAxis("Mouse X");
    }

    public static float MouseY()
    {
        return Input.GetAxis("Mouse Y");
    }

    public static bool P_Key_Down()
    {
        return Input.GetKeyDown(KeyCode.P);
    }

    public static bool SpaceBar_Key_down()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

}