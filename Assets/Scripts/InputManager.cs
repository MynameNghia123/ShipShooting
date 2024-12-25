using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance;  }

    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos;  }


    private void Awake()
    {
        if(InputManager.instance != null) { Debug.LogError("Only 1 InputManager allow to exist"); }
        instance = this;
    }
    private void FixedUpdate()
    {
        this.GetMousePosition();
    }
    protected virtual void GetMousePosition()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
}
