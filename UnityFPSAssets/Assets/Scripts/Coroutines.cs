using System.Collections;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    public GameObject cube;
    public Light dirLight;
    public int cycleHours = 24; //Hours factor
    public float cycleTime = 10f; //Time speed of our light


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(MoveCubeUpwords());
        StartCoroutine(DayNightCycle());

    }

    private IEnumerator MoveCubeUpwords()
    {
        float inTime = 3f; //Time in which the cube will move
        float t = 0f; //Time start

        //Version 1
        //while (t < intime) //while our time is smaller than our max time
        //{
        //    cube.transform.translate(vector3.up * time.deltatime); //we move the cube up each frame the computer can run
        //    t += time.deltatime; //starting from 0, we add up every frame calculation time (eg. 0.003s)
        //    yield return null;
        //}

        //version 2
        float origY = cube.transform.position.y; //Cube initial Y position
        while(t < inTime)
        {
            cube.transform.position = new Vector3(cube.transform.position.x, origY + t, cube.transform.position.z); //OrigY incremented of Time.deltaTime

            t += Time.deltaTime;
            yield return null;
        }
        //Force positioning the cube at wanted position
        cube.transform.position = new Vector3(0f, 3f, 0f);

    }
    
    private IEnumerator DayNightCycle()
    {
        if (cycleTime > 0f && cycleHours > 0) // If cycle time and cycle hours are positive values
        {
            float cycleTimeFactor = 24f / cycleHours; // Returns a value > 0 if cycleHours is < 24, or vice versa

            /*Version 1 (not quite working)
            float startXRot = dirLight.transform.localEulerAngles.x; // This is the local x rotation value given in Euler angles (NOT quaternions)
            float endRot = startXRot + 360f;
            */

            /*Version 2 (Quaternions)
            Quaternion startRot = dirLight.transform.localRotation;
            Vector3 rot = dirLight.transform.localEulerAngles;
            rot.x += 360;
            Quaternion endRot = Quaternion.Euler(rot); //Setup new ending rotation (+360f)
            */

            for (float t = 0f; t < cycleTime; t = Time.deltaTime)
            {
                /*Version 1
                float xRotation = Mathf.Lerp(startXRot, endRot, t / cycleTime) % 360f; // Lerping from 0 to 1, from value1 to value2
                dirLight.transform.localEulerAngles = new Vector3(xRotation,
                                                                  dirLight.transform.localEulerAngles.y,
                                                                  dirLight.transform.localEulerAngles.z); // Setting rotation

                */
                /*Version 2
                dirLight.transform.localRotation = Quaternion.Slerp(startRot, endRot, t / cycleTime); //Lerping angles using Quaternion
                */

                //Version 3 (Working)
                dirLight.transform.Rotate(Vector3.right, 360f * Time.deltaTime / (cycleTime * cycleTimeFactor), Space.Self);
                yield return null;
            }

        }
        else
        {
            Debug.LogWarning("Cycle hours and time cannot be negative values!");
        }
        yield return null;
    }

}
