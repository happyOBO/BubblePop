using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        Unknown,
        Game,
    }

    public enum WorldObject
    {
        Unknown,
        Player,
        Bubble,
    }

    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointerUp,
        Click,
    }

    public enum BubbleColor
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        Yellow = 3,
    }
}
