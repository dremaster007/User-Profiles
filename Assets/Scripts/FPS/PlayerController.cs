using System.Collections;
using UnityEngine;

public class PlayerController : Controller
{

    public float moveHorizontal = 0f;
    public float moveVertical = 0f;
    private float modSpeed = 0f;


    private void Start()
    {
        
    }

    private void Update()
    {
        if(!GameManager.isGamePaused && GameManager.playerCurrLife > 0f)
        {
            //Movement
            #region Movement
            GameManager.playerIsWalking = false;
            modSpeed = 0f;

            //Walk
            if (GameManager.playerCanWalk)
            {
                if (!GameManager.playerIsJumping)
                {
                    moveHorizontal = 0f;
                    moveVertical = 0f;
                    moveHorizontal += InputManager.HorizontalAxis();
                    moveVertical += InputManager.VerticalAxis();

                    if(moveHorizontal != 0 || moveVertical != 0f) // If we are moving at all in either direction
                    {
                        GameManager.playerIsWalking = true;

                        //Move forward/backward
                        Vector3 nextPosFB = new Vector3(-Vector3.Dot(Camera.main.transform.right,Vector3.forward),
                                                        0f,
                                                        Vector3.Dot(Camera.main.transform.right, Vector3.right));

                        if(moveVertical > 0f)
                        {
                            transform.position += nextPosFB * Time.deltaTime * (GameManager.playerWalkSpeed + modSpeed);
                        }
                        else if(moveVertical < 0f)
                        {
                            transform.position -= nextPosFB * Time.deltaTime * (GameManager.playerWalkSpeed + modSpeed);
                        }

                        //Move rightward/leftward
                        Vector3 nextPosRL = Camera.main.transform.right * (GameManager.playerWalkSpeed + modSpeed) * 0.8f;

                        if(moveHorizontal > 0f)
                        {
                            transform.position += nextPosRL * Time.deltaTime;
                        }
                        else if(moveHorizontal < 0f)
                        {
                            transform.position -= nextPosRL * Time.deltaTime;
                        }
                    }

                    //Jumping
                    if(GameManager.playerCanJump && InputManager.SpaceBar_Key_down())
                    {
                        GameManager.playerIsJumping = true;
                        Vector3 pushDir = new Vector3(-Vector3.Dot(Camera.main.transform.right, Vector3.forward) * Mathf.Max(moveVertical * 0.5f, 0f),
                                                       1f,
                                                       Vector3.Dot(Camera.main.transform.right, Vector3.right) * Mathf.Max(moveVertical * 0.5f, 0f));

                        Vector3 pushLat = Vector3.Cross(Camera.main.transform.forward, Vector3.up).normalized * (-moveHorizontal * 0.5f);

                        GetComponent<Rigidbody>().AddForce((pushDir + pushLat) * GameManager.playerJumpMagnitude);
                    }
                }
            }
            #endregion
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.playerIsJumping)
        {
            StartCoroutine(CanJumpAgain());
        }
    }

    private IEnumerator CanJumpAgain()
    {
        GameManager.playerCanJump = false;
        yield return new WaitForSeconds(0.3f);
        GameManager.playerIsJumping = false;
        GameManager.playerCanJump = true;
    }
}
