using UnityEngine;
public class PauseManager
{
    private static float prevTimeScale = 1f;

    public static void PauseGame()
    {
        if (!GameManager.isGamePaused)
        {
            GameManager.isGamePaused = true;

            prevTimeScale = Time.timeScale;
            Time.timeScale = 0.00001f;

            Debug.Log("GAME PAUSED");
        }
    }

    public static void ResumeGame()
    {
        if (GameManager.isGamePaused)
        {
            GameManager.isGamePaused = false;
            Time.timeScale = prevTimeScale;

            Debug.Log("GAME RESUMED");
        }
    }
}
