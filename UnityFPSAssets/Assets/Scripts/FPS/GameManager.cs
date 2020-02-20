using UnityEngine;
public class GameManager
{
    //Global Variables
    public static bool isDebug = false; // This is used to track if we are in debug mode
    public static bool isGamePaused = false; // This is used to track if we are pausing the game
    public static float objInteractMaxDist = 2f; // This is to tell us how far the player can interact with an object
    public static float cameraRigHeight = 0.75f; // This is to hold how high up the camera will be

    //Player
    public static float playerCurrLife = 1f; // This is to hold our players current life
    public static float playerMaxLife = 1f; // This is to hold our players maximum life
    public static float playerWalkSpeed = 1.5f; // This is to hold our walk speed
    public static float playerJumpMagnitude = 18000f; // This is to hold our Jump force
    public static bool playerCanWalk = true; // This tracks whether or not we can walk
    public static bool playerCanJump = true; // This tracks whether or not we can jump
    public static bool playerIsWalking = false; // This tracks if we are currently walking
    public static bool playerIsJumping = false; // This tracks if we are currently jumping
    public static bool playerCanControlCamera = true; // This is to hold if we can control our camera

    //Interacting Game Objects Tags
    public static string untaggedTag = "Untagged"; // This is to track untagged objects
    public static string interactingObjectTag = "interactingObjectTag"; // This is to track an object that can interact
    public static string collectingObjectTag = "collectingObjectTag"; // This is to track an object that we can collect
    public static string[] interactingObjectsTagsArray = new string[2] { interactingObjectTag, collectingObjectTag }; // This is to add the 2 tags above into this array

    //Reset
    public static void ResetVariables()
    {
        playerCurrLife = playerMaxLife; // Here we set our current life back up to our max life
        playerCanWalk = true;
        playerCanJump = true;
        playerIsWalking = false;
        playerIsJumping = false;
        playerCanControlCamera = true;

        Debug.Log("Variables reset!");
    }
}
