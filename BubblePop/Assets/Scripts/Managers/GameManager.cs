using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{

    GameObject _player;
    List<GameObject> _bubbles = new List<GameObject>();

    public GameObject GetPlayer() { return _player; }

    public GameObject Spawn(Define.WorldObject type, string path, Transform parent = null)
    {
        GameObject go = null;

        switch (type)
        {
            
            case Define.WorldObject.Player:
            {
                go = Managers.Resource.Instantiate(path, parent);
                _player = go;
                break;

            }

            case Define.WorldObject.Bubble:
            {
                System.Random rand = new System.Random();
                Define.BubbleColor bubbleType = (Define.BubbleColor)rand.Next(0, 4);
                go = Managers.Resource.Instantiate($"{path}/{bubbleType.ToString()}", parent);
                BubbleController bubble = go.GetComponent<BubbleController>();
                bubble.bubbleColor = bubbleType;
                _bubbles.Add(go);
                break;
            }

        }

        return go;
    }
}
