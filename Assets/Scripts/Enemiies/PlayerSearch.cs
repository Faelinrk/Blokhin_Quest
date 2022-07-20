using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Enemies
{
    public class PlayerSearch : MonoBehaviour
    {
        public bool LookForPlayer(Transform player, Ray ray,Transform eyes, float visionDist)
        {
            Vector3 targetDirection = player.position - transform.position;
            ray = new Ray(eyes.position,targetDirection);
            Debug.DrawRay(eyes.position,targetDirection);
            if (Physics.Raycast(ray, out RaycastHit hit,visionDist))
            {
                Debug.Log(hit.transform.tag);
                if (hit.transform.CompareTag(Constants.PlayerTag))
                {
                    return true;
                }
            }
            return false;
        }
    }

}
