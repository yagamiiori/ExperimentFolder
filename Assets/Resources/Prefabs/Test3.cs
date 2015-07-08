using UnityEngine;
using System.Collections;

public class Test3 : MonoBehaviour {

    // -------------------------------------------------------------------
    // 入室ボタンがクリックした時に入室ボタンのOnClickからコールされる
    // 部屋を作成する。
    // -------------------------------------------------------------------
    public void RoomIn()
    {
        Application.LoadLevel("BattleStage");
    }
}
