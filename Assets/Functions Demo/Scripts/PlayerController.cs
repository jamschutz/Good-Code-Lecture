using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 minMaxSize;

    private float minYPosition = -4.33f;
    private float maxYPosition = 6.11f;public Transform[] objectsInScene;


    private void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        float heightAsPercent = (transform.position.y - minYPosition) / (maxYPosition - minYPosition);
        float scale = Mathf.Lerp(minMaxSize.x, minMaxSize.y, heightAsPercent);
        transform.localScale = new Vector3(scale, scale, scale);

        foreach(var obj in objectsInScene) {
            obj.GetComponent<SpriteRenderer>().color = Color.blue;
        }

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
