using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent MetalMode = new UnityEvent();
    public UnityEvent ChillMode = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        ChillMode.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
