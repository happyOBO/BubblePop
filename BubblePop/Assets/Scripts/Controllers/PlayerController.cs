using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    BubbleController bubble;

    void Start()
    {
		Managers.Input.MouseAction -= OnMouseEvent;
		Managers.Input.MouseAction += OnMouseEvent;
	}

    // Update is called once per frame
    void Update()
    {
        if(bubble == null)
        {
            GameObject go = Managers.Game.Spawn(Define.WorldObject.Bubble, "Bubble", gameObject.transform);
            bubble = go.GetComponent<BubbleController>();
        }
    }

	void OnMouseEvent(Define.MouseEvent evt)
	{
		switch (evt)
		{
			case Define.MouseEvent.Press:
                {
                    // rotate bubble according to mouse position
                    Debug.Log($"{evt}");
                    break;
                }
            case Define.MouseEvent.PointerDown:
                {
                    // show shoot path
                    Debug.Log($"{evt}");
                    break;
                }
            case Define.MouseEvent.PointerUp:
                {
                    // Shoot the Bubble
                    // path ���� �� ���
                    Debug.Log($"{evt}");
                    break;
                }
        }
	}
}
