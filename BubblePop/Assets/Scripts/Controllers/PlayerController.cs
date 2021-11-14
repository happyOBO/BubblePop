using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    BubbleController _bubble;
    float uiWidthHalf = 2.8f;
    float uiHeightHalf = 5.0f;


    void Start()
    {
		Managers.Input.MouseAction -= OnMouseEvent;
		Managers.Input.MouseAction += OnMouseEvent;
	}

    // Update is called once per frame
    void Update()
    {
        if(_bubble == null)
        {
            System.Random rand = new System.Random();
            Define.BubbleColor bubbleColor = (Define.BubbleColor)rand.Next(0, 4);
            GameObject go = Managers.Game.Spawn(Define.WorldObject.Bubble, $"Bubble/{bubbleColor.ToString()}", gameObject.transform);
            _bubble = go.GetComponent<BubbleController>();
        }
    }
    
	void OnMouseEvent(Define.MouseEvent evt)
	{
		switch (evt)
		{
			case Define.MouseEvent.Press:
                {
                    drawShootLine();
                    break;
                }
            case Define.MouseEvent.PointerDown:
                {
                    // show shoot path
                    // set active true
                    Managers.Game.GetShootLine().SetActive(true);
                    break;
                }
            case Define.MouseEvent.PointerUp:
                {
                    // Shoot the Bubble
                    // path 보간 및 기록
                    // set active false
                    Managers.Game.GetShootLine().SetActive(false);

                    break;
                }
        }



        void drawShootLine()
        {
            LineRenderer line = Managers.Game.GetShootLine().GetComponent<LineRenderer>();
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition -= new Vector3(0.0f, 0.0f, 1.0f) * Camera.main.ScreenToWorldPoint(Input.mousePosition).z;
            Vector3 playerWorldPosition = Managers.Game.GetPlayer().transform.position;
            Vector3 pTmp = isReachedBubbles(playerWorldPosition, mouseWorldPosition);
            //line.positionCount = 3;
            Vector3[] points = new Vector3[] { playerWorldPosition, pTmp};

            Color c1 = Color.yellow;
            Color c2 = Color.red;
            line.startColor = c1;
            line.endColor = c2;
            line.startWidth = 0.1f;
            line.endWidth = 0.1f;
            line.SetPositions(points);
            

        }

        Vector3 isReachedBubbles(Vector3 Position1, Vector3 Position2)
        {
            List<GameObject> bubbles = Managers.Game.GetBubbles();
            float minDistWithBubble = int.MaxValue;
            GameObject minDistBubble = null;
            Vector3 targetPosition = new Vector3();
            foreach (GameObject bubble in bubbles)
            {
                if (bubble.GetComponent<BubbleController>().bubbleType == Define.BubbleType.Shoot)
                    continue;
                Vector3 bubblePosition = bubble.transform.position;
                float dist = calcDistance(Position1, Position2, bubblePosition);
                if (bubblePosition.x == 0.0f)
                    Debug.Log("");
                if (dist < 0.5f)
                {
                    if (minDistWithBubble > Vector3.Distance(Position1, bubblePosition))
                    {
                        minDistWithBubble = Vector3.Distance(Position1, bubblePosition);
                        minDistBubble = bubble;
                    }
                }
            }

            if(minDistWithBubble < int.MaxValue)
            {

                targetPosition = calcPoint(Position1, Position2, minDistBubble.transform.position.y - 0.4f);
                return targetPosition;
            }

            return targetPosition;
        }

        float calcDistance(Vector3 linePoint1, Vector3 linePoint2, Vector3 Point)
        {
            float Dist;
            float x1 = linePoint1.x; float y1 = linePoint1.y;  float x2 = linePoint2.x; float y2 = linePoint2.y;
            float x = Point.x;  float y = Point.y;
            if (Point.x == 0.0f)
                Dist = 0.0f;
            else
            {
                float a = (y1 - y2) / (x1 - x2);
                Dist = Mathf.Abs(a * (x - x1) - y + y1) / Mathf.Sqrt(a * a + 1);

            }
            return Dist;
        }

        Vector3 calcPoint(Vector3 linePoint1, Vector3 linePoint2, float posY)
        {
            Vector3 Position;
            float x1 = linePoint1.x; float y1 = linePoint1.y; float x2 = linePoint2.x; float y2 = linePoint2.y;
            if (x1 == x2)
                Position = new Vector3(x1, posY, 0.0f);
            else
            {
                float a = (y1 - y2) / (x1 - x2);
                Position = new Vector3((posY - y1) / a + x1, posY,0.0f);
            }
            return Position;
        }
    }
}
