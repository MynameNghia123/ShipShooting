using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance;  }

    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos;  }

    [SerializeField] private float onFiring;
    public float OnFiring { get => onFiring; }

    private void Awake()
    {
        if(InputManager.instance != null) { Debug.LogError("Only 1 InputManager allow to exist"); }
        instance = this;
    }
    private void Update()
    {
        this.GetMouseDown();
        this.GetMousePosition();
    }
    protected virtual void GetMousePosition()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
