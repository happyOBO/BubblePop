using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{

    // Start is called before the first frame update
    public static List<List<BubbleController>> bubbleBoard;
    public static float bubbleRadius = 0.6f;
    System.Random rand = new System.Random();

    void Start()
    {
        getBoard(9, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public List<List<BubbleController>> getBoard(int maxWidth, int Height)
    {
        bubbleBoard = new List<List<BubbleController>>();
        for (int row = 0; row < Height; row++)
        {
            List<BubbleController> bubbleRow;
            if (row % 2 == 1)
                fillBubbles(out bubbleRow, 9, row);
            else
                fillBubbles(out bubbleRow, 8, row );

            bubbleBoard.Add(bubbleRow);
        }


        return null;
    }

    public void fillBubbles(out List<BubbleController> bubbleRow, int count, int rowIdx)
    {
        Define.BubbleColor prevBubbleColor = Define.BubbleColor.Unknown;
        float startPosX = 0.0f ;
        float startPosY = 0.0f;

        if(rowIdx % 2 == 1)
        {
            startPosY = rowIdx * bubbleRadius;
        }
        else
        {
            startPosX = bubbleRadius / 2.0f;
            startPosY = rowIdx * bubbleRadius;
        }
        bubbleRow = new List<BubbleController>();
        for (int i = 0; i < count; i++)
        {
            BubbleController bc = getBubbleRandomly(prevBubbleColor);
            prevBubbleColor = bc.bubbleColor;
            
            bc.transform.position += (Vector3.right * startPosX + Vector3.right * bubbleRadius * i);
            bc.transform.position += (Vector3.down * startPosY);
            bubbleRow.Add(bc);
        }
    }

    public BubbleController getBubbleRandomly(Define.BubbleColor prevBubbleColor = Define.BubbleColor.Unknown)
    {
        // 쓸데 없이 복잡해져서 간단하게 만들기로
        // 5개 더 추가해서 4 이상의 숫자가 나오면 prevBubbleColor 당첨
        Define.BubbleColor bubbleColor;
        int targetNum = rand.Next(0, 4 + 5);
        if (prevBubbleColor == Define.BubbleColor.Unknown)
            bubbleColor = (Define.BubbleColor)(targetNum % 4);
        else if (4 <= targetNum)
            bubbleColor = prevBubbleColor;
        else
            bubbleColor = (Define.BubbleColor)targetNum;
        GameObject go = Managers.Game.Spawn(Define.WorldObject.Bubble, $"Bubble/{bubbleColor.ToString()}", gameObject.transform);
        return go.GetComponent<BubbleController>();

    }

}
