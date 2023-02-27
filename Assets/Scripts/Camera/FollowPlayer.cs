using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player; // the player object
    Vector3 offset; // for camera displacemnt and how closely zoomed it is

    // Start is called before the first frame update
    void Start()
    {
        offset.z = -15;
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform the position of the camera
        // by giving all the coordinates of the player excpet the z (zoom)
        transform.position = new Vector3(player.position.x, player.position.y, offset.z);
        
    }
}
