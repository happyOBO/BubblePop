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
            System.Random rand = new System.Random();
            Define.BubbleColor bubbleColor = (Define.BubbleColor)rand.Next(0, 4);
            GameObject go = Managers.Game.Spawn(Define.WorldObject.Bubble, $"Bubble/{bubbleColor.ToString()}", gameObject.transform);
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
                    // path 보간 및 기록
                    Debug.Log($"{evt}");
                    break;
                }
        }
	}
}
