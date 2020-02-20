using UnityEngine;
public class Controller : MonoBehaviour
{
    protected bool CanObjectBeInteracted(ref GameObject obj)
    {
        if(obj == null)
        {
            return false;
        }
        for(int i = 0; i < GameManager.interactingObjectsTagsArray.Length; i++)
        {
            if (obj.tag.Equals(GameManager.interactingObjectsTagsArray[i]))
            {
                if(DistanceOk(ref obj))
                {
                    return true;
                }
            }
        }
        return false;
    }

    protected bool DistanceOk(ref GameObject obj)
    {
        if(obj == null)
        {
            return false;
        }
        if (transform.position.x < (obj.transform.position.x + GameManager.objInteractMaxDist)
            && transform.position.x > (obj.transform.position.x - GameManager.objInteractMaxDist)
            && transform.position.y < (obj.transform.position.y + GameManager.objInteractMaxDist)
            && transform.position.y > (obj.transform.position.y - GameManager.objInteractMaxDist)
            && transform.position.z < (obj.transform.position.y + GameManager.objInteractMaxDist)
            && transform.position.z > (obj.transform.position.y - GameManager.objInteractMaxDist))
        {
            return true;
        }
        return false;
    }
}
