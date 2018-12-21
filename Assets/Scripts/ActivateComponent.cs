using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *  Will rewrite later for actual pick ups/powerups
 */
public class ActivateComponent : MonoBehaviour
{
    public GrapplingHook component;
    public GameObject item;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ActivateComponents();
    }

    void ActivateComponents()
    {
        component.enabled = true;
        item.SetActive(true);
    }
}
