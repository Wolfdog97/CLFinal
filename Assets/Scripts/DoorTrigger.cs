using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    public GameObject target;
    public bool turnOn;

    public List<GameObject> objectsToTurnOn;
    public List<GameObject> objectsToTurnoff;

    private void OnTriggerEnter(Collider other)
    {
       

            if (turnOn)
            {
                //Turn on the wall
                foreach (GameObject thisObject in objectsToTurnOn)
                {
                    thisObject.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject thisObject in objectsToTurnoff)
                {
                    thisObject.SetActive(false);
                }
            }
    }
}
