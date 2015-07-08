using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;    //CP専用Hashtable

public class PlayerCount : MonoBehaviour
{
    public PhotonPlayer[] playerAllProp;     // 全ユーザ情報
    public int playerAll;                    // 全ユーザ数（接続人数）
    private Text playerAllText;              // 全ユーザー数表示用テキストコンポ

	void Start ()
    {
        // 全ユーザ数表示オブジェクトとTextコンポを取得
        playerAllText = GameObject.FindWithTag("Roby_PlayersNum").GetComponent<Text>();

        // ゲーム中プレイヤー数取得メソッドをコール
        StartCoroutine("GetPlayerAll");
	}

    // -------------------------------------------------------------
    // 全プレイヤー数取得メソッド
    // 全ゲーム中のプレイヤー数を取得し、Textコンポに表示する
    // Start()メソッドからコールされ、コルーチンとして定期的に更新する
    // -------------------------------------------------------------
    private IEnumerator GetPlayerAll()
    {
        while (true)
        {
            playerAllText.text = PhotonNetwork.playerList.Length.ToString();

            // 一時停止
            yield return new WaitForSeconds(20.0f);
        }
    }
}
