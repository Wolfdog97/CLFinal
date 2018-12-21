using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    
    public float timeUntilAction = 1f;
    protected float _timer;
    public bool repeat = false;
    public bool printTime;
    
    public UnityEvent actionToPerform;
    
    // Start is called before the first frame update
    void Start()
    {
        _timer = timeUntilAction;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0) {
            actionToPerform.Invoke();
            if (repeat) {
                _timer = timeUntilAction;
            }
            else {
                gameObject.SetActive(false);
            }
        }

        if (printTime)
        {
            Debug.Log("Timer at: " +_timer);
        }
        
    }
}
