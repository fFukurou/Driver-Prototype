using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] GameObject thingToFollow;
    // The camera position should be the same as the car's.


    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new UnityEngine.Vector3(0, 0, -30);

    }
}
