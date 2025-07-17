using UnityEngine;
// Include the System.Collections.Generic library to access extra functionality
using System.Collections.Generic;
using System;

// Keep the MonoBehavior parent class so our Controller children classes inherit all of the methods and properties from that class
public abstract class Controller : MonoBehaviour
{
    // Create and define the body the controller will "control/use" so it can be used for multiple objects with the same code
    // Set this to public so it can be accessed outside of this class, {This also serializes this data, which allows it to be accessed/modified within the editor}
    // NOTE: There is no need for this data to be accessable within the inspector
    [HideInInspector] public Pawn pawn;

    public abstract void Awake();
    // Create the abstract function definintions, so they can be defined within the child controller class
    public abstract void Start();
    public abstract void Update();
    // Create a function that will make descisions based on the input it recieves. 
    public abstract void MakeDescisions();
}
