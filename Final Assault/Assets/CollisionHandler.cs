using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        DisableTriggerOnCrash();
    }

    private void DisableTriggerOnCrash()
    {
        print("The ship collided");
        SendMessage("CrashReporter");
    }
}
