using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{

    GameObject _player;
    List<GameObject> _bubbles = new List<GameObject>();
    GameObject _board;
    public GameObject GetPlayer() { return _player; }
    public List<GameObject> GetBubbles() { return _bubbles; }
    public GameObject GetBoard() { return _board; }

    public GameObject Spawn(Define.WorldObject type, string path, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);

        switch (type)
        {
            
            case Define.WorldObject.Player:
            {
                _player = go;
                break;

            }

            case Define.WorldObject.Bubble:
            {

                string bubbleColorName = path.Split(new char[] { '/' })[1];
                 Debug.Log($"{bubbleColorName}");
                switch (bubbleColorName)
                {
                    case "Blue":
                        go.GetComponent<BubbleController>().bubbleColor = Define.BubbleColor.Blue;
                        break;
                    case "Red":
                        go.GetComponent<BubbleController>().bubbleColor = Define.BubbleColor.Red;
                        break;
                    case "Green":
                        go.GetComponent<BubbleController>().bubbleColor = Define.BubbleColor.Green;
                        break;
                    case "Yellow":
                        go.GetComponent<BubbleController>().bubbleColor = Define.BubbleColor.Yellow;
                        break;
                }
                _bubbles.Add(go);
                break;
            }
            case Define.WorldObject.Board:
            {
                _board = go;
                break;
            }
        }

        return go;
    }
}
