using UnityEngine;
public class RayCastManager
{
    public static GameObject GetRayCastedObjectToCamera()
    {
        //Builds a ray from camera point of view to camera forward
        Transform cam = Camera.main.transform;
        Ray ray = new Ray(cam.position, cam.forward);

        RaycastHit hit;
        //Casts the ray and gets the first game object hit
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return hit.transform.gameObject;
        }

        return null;
    }
}
