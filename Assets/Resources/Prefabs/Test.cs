using UnityEngine;
using System.Collections;

public class Test : Photon.MonoBehaviour {

    // プレイヤー歩行速度
    private float speed = 0.5f;
    // キャラ移動値スタック
    private Vector2 vel = Vector2.zero;

	void Update ()
    {
        // 自分のオブジェクトの場合
        if (photonView.isMine)
        {
            // 左右方向キー判定（-1:左キー　1：右キー）
            int input_facing = (int)Input.GetAxisRaw("Horizontal");

            // 上下方向キー判定（-1:下キー　1：上キー）
            int input_facing2 = (int)Input.GetAxisRaw("Vertical");

            // 移動実施
            this.transform.position = vel;

            // 右に移動する場合
            // 左右のアニメは変更しないためlocalscaleで向きだけ変える
            if (input_facing == 1)
            {
                // 右に移動
                vel.x += speed;

                //左に移動する場合
            }
            else if (input_facing == -1)
            {
                // 左に移動
                vel.x -= speed;
            }

            //上に移動する場合
            if (input_facing2 == 1)
            {
                // 上に移動
                vel.y += speed;
            }
            //下に移動する場合
            else if (input_facing2 == -1)
            {
                // 下に移動
                vel.y -= speed;
            }
        }
    }
}
