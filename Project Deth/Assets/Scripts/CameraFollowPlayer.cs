using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Public Variables
    public Transform FollowTarget;

    // Private Variables
    private Cinemachine.CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

 
    void FixedUpdate()
    {
        if (FollowTarget == null) { FindPlayer(); }
    }
    
    void FindPlayer()
    {
        GameObject SearchResult = GameObject.FindGameObjectWithTag("Player");
        if (SearchResult != null) { vcam.Follow = SearchResult.transform; }
    }
}
