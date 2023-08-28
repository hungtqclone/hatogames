using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }
    
    [SerializeField] protected float horizontal;
    public float Horizontal { get => horizontal; }
    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }

    private void FixedUpdate()
    {
        this.GetMoveX();
    }

    protected virtual void GetMoveX()
    {
        this.horizontal = Input.GetAxis("Horizontal");
    }
}
