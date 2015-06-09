using UnityEngine;
using System.Collections;
////////////////////////////////////////////////////////////////////////////////////////
//　関数名：オブジェクト追随クラス（CameraStalking）
//　機能：特定のオブジェクトにカメラを追随させる
//　継承：MonoBehaviour
//　種別：通常クラス
//　アタッチ先：メインカメラオブジェクト
//　保持メソッド：なし
//　リダイレクト：
//
//　詳細：
//　　　　カメラを特定のオブジェクトに追随させる
//　　　　本スクリプトはメインカメラにアタッチして使用する
//
//　履歴：
//　　　　14.12.12 初版
//　　　　14.12.13 衝突による再判定バグのため改修
//
////////////////////////////////////////////////////////////////////////////////////////
public class CameraStalking : MonoBehaviour
{
    // マウスカーソルの位置
    private Vector3 mousePos;
    // キャラ追随用オフセット
    public Vector3 offset = Vector3.zero;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;

    // 毎F実行関数
    void Update()
    {
        // Vector3でマウス位置座標を取得する
        mousePos = Input.mousePosition;

        // Z軸修正
        mousePos.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(mousePos);
        // ワールド座標に変換されたマウス座標を代入
        this.gameObject.transform.position = screenToWorldPointPosition;
    }
}



