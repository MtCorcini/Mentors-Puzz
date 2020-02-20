using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public  Transform player;  // reference to the player´s transform. 
    public float cameraDistance;
    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.width / 5) / cameraDistance);
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y,transform.position.z);
    }
}
 