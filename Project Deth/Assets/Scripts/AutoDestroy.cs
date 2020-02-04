using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    // Just destroys the object after Animation + delay
    [SerializeField] private float delay = 0f;
    
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

}
