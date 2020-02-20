using UnityEngine;

public class Main : MonoBehaviour
{
    void Start()
    {
        GameManager.ResetVariables();
    }

    void Update()
    {
        try
        {
            Debug.Log("RayCasted object is: " + RayCastManager.GetRayCastedObjectToCamera().name);
        }
        catch
        {
            Debug.LogWarning("Error in raycasting!");
        }

        #region Pause / Resume
        if (InputManager.P_Key_Down())
        {
            if (GameManager.isGamePaused)
            {
                PauseManager.ResumeGame();
            }
            else
            {
                PauseManager.PauseGame();
            }
        }
        #endregion
    }
}
