using System;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Awake runs when the object is created, but just before it enters the world
    private void Awake()
    {
        Debug.Log("Awakening...");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello, World!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
