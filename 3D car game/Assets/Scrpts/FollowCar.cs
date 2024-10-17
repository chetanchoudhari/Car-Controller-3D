using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform carTransform;
    public Transform cameraPointTransform;
    private Vector3 veloCity = Vector3.zero;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(carTransform);
        transform.position = Vector3.SmoothDamp(transform.position ,cameraPointTransform.position, ref veloCity,5f * Time.deltaTime);
    }
}
