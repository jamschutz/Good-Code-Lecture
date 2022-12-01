using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnClosestObjectRed : MonoBehaviour
{
    public Transform[] objectsInScene;

    void Update()
    {
        TurnObjectsTowardPlayer();
        var closestObject = GetClosestObject();
        TurnAllObjectsWhite();
        TurnObjectRed(closestObject);
    }



    public Transform GetClosestObject()
    {
        float bestDistance = float.PositiveInfinity;
        Transform closestObject = null;

        foreach(var obj in objectsInScene) {
            float distance = Vector3.Distance(transform.position, obj.position);
            if(distance < bestDistance) {
                bestDistance  = Vector3.Distance(transform.position, obj.position);
                closestObject = obj;
            }
        }

        return closestObject;
    }


    public void TurnObjectRed(Transform obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = Color.red;
    }


    public void TurnObjectsTowardPlayer()
    {
        Transform player = Camera.main.transform;
        foreach(var obj in objectsInScene) {
            obj.LookAt(player);
        }
    }


    private void TurnAllObjectsWhite()
    {
        foreach(var obj in objectsInScene) {
            obj.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
