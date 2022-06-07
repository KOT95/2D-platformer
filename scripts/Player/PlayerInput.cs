using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action<float> Moving = default;
    public event Action Jumping = default;
    
    public float Horizontal { get; private set; }
    private bool _jump;

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        _jump = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);

        if (Moving != null)
            Moving(Horizontal);

        if (_jump && Jumping != null)
            Jumping();
    }
}
