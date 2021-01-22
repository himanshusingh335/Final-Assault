using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        DisableTriggerOnCrash();
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void DisableTriggerOnCrash()
    {
        SendMessage("CrashReporter");
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
