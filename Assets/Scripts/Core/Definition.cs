using System;
using Unity;
using UnityEngine;

public class Definition
{
    public static void StateStackDebug(string message)
    {
        Debug.Log("State Stack: " + message);
    }

    public static void InteractableDebugLog(string message)
    {
        Debug.Log("Interactable Object: " + message);
    }

    public static void InitalizeErrors(string message)
    {
        Debug.Log ("Initialize erros: " + message);
    }
}