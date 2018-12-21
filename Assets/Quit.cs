using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

//ignore the name
public class Quit : MonoBehaviour
{
    public UnityEvent actionToPerform;
    
    private void OnTriggerEnter(Collider other)
    {
        actionToPerform.Invoke();
    }
}
