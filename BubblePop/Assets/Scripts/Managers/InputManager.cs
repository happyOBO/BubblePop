using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action<Define.MouseEvent> MouseAction = null;

    bool _pressed = false;
    float _pressedTime = 0.0f;

    public void OnUpdate()
    {
        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                if (!_pressed) MouseAction.Invoke(Define.MouseEvent.PointerDown);

                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if (_pressed) MouseAction.Invoke(Define.MouseEvent.PointerUp);

                _pressed = false;
            }
        }
    }

    public void Clear()
    {
        MouseAction = null;
    }
}