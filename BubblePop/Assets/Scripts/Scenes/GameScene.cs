using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{

    protected override void Init()
    {
        base.Init();


        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "Player");
        GameObject board = Managers.Game.Spawn(Define.WorldObject.Board, "Board");
        GameObject shootLine = Managers.Game.Spawn(Define.WorldObject.ShootLine, "ShootLine");

    }
    IEnumerator SpawnAfterSeconds(float seconds, GameObject monster)
    {
        yield return new WaitForSeconds(seconds);
        monster.SetActive(true);

    }

    public override void Clear()
    {
    }
}
