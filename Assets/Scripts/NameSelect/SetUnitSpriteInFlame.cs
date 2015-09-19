using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// ユニット画像表示クラス
/// <para>　属する枠内にユニットの画像を表示する</para>
/// </summary>
public class SetUnitSpriteInFlame : MonoBehaviour
{
    /// <summary>
    /// ユニット画像表示メソッド
    /// <para>　属する枠内にユニットの画像を表示する</para>
    /// <param name="parentGO">表示するユニット画像の親となるゲームオブジェクト</param>
    /// <param name="setVector">表示するユニット画像の表示位置(Vector3)</param>
    /// <param name="gameManager">ゲームマネージャー</param>
    /// <param name="unitID">GetMyUnitIDメソッドで取得したユニットID</param>
    /// </summary>
    public void UnitSpriteSet(GameObject parentGO, Vector3 setSpriteVec, GameManager gameManager, int unitID)
    {
        /// <summary>属するユニット画像のゲームオブジェクトの名前</summary>
        string spriteName = "UnitSprite" + unitID.ToString();
        /// <summary>ユニット画像スプライト（GameObject）</summary>
        GameObject sprite;
        /// <summary>ユニット画像スプライト（Perfab）</summary>
        GameObject prefab;

        // 同名のゲームオブジェクトが既に存在するか検索
        GameObject alreadyExistSprite = GameObject.Find(spriteName);
        if (null != alreadyExistSprite)
        {
            // 同名のゲームオブジェクトがある場合は消去する
            Destroy(alreadyExistSprite);
        }

        // クラスIDを読み出し
        switch (gameManager.unitStateList[unitID].classType)
        {
                // ソルジャーの場合
                case Defines.SOLDLER:
                    // ソルジャーのスプライトを設定
                    sprite = Resources.Load("UnitSprite_NameSelect/Char_1") as GameObject;
                    // prefabを表示
                    prefab = Instantiate(sprite, setSpriteVec, Quaternion.identity) as GameObject;
                    prefab.transform.SetParent(parentGO.transform, false);
                    prefab.name = spriteName;
                    break;

                // ウィザードの場合
                case Defines.WIZARD:
                    // ウィザードのスプライトを設定
                    sprite = Resources.Load("UnitSprite_NameSelect/Char_2") as GameObject;
                    // prefabを表示
                    prefab = Instantiate(sprite, setSpriteVec, Quaternion.identity) as GameObject;
                    prefab.transform.SetParent(parentGO.transform, false);
                    prefab.name = spriteName;
                    break;

                // ユニット未設定の場合
                default:
                    break;
        }
    }
}
