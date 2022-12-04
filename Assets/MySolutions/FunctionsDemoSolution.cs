using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsDemoSolution : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 minMaxSize;
    public float scaleOnMouseDown;

    private float minYPosition = -4.33f;
    private float maxYPosition = 6.11f;public Transform[] objectsInScene;

    private const int LEFT_MOUSE_BUTTON = 0;


    private void Update()
    {
        MovePlayer();
        ScalePlayer();
        TurnAllObjectsBlue();
        TurnClosestObjectRed();
    }


    private void MovePlayer()
    {
        void Move(Vector3 direction) 
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.W)) Move(Vector3.up);
        if(Input.GetKey(KeyCode.A)) Move(Vector3.left);
        if(Input.GetKey(KeyCode.S)) Move(Vector3.down);
        if(Input.GetKey(KeyCode.D)) Move(Vector3.right);
    }


    private void ScalePlayer()
    {
        if(Input.GetMouseButton(LEFT_MOUSE_BUTTON)) {
            transform.localScale = new Vector3(scaleOnMouseDown, scaleOnMouseDown, scaleOnMouseDown);
        }
        else {
            float heightAsPercent = (transform.position.y - minYPosition) / (maxYPosition - minYPosition);
            float scale = Mathf.Lerp(minMaxSize.x, minMaxSize.y, heightAsPercent);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }


    private void TurnAllObjectsBlue()
    {
        foreach(var obj in objectsInScene) {
            obj.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }


    private void TurnClosestObjectRed()
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

        closestObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
