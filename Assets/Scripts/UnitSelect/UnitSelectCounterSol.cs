using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class UnitSelectCounterSol : MonoBehaviour {

    private GameManager gameManager;                // マネージャコンポ
    private Text a;

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        
        // Textコンポを取得
        a = this.gameObject.GetComponent<Text>();
    }

	void Update ()
    {
        // 現在選択されているユニット数を文字列変換して表示
        a.text = gameManager.unt_Sodler.ToString();
	}
}
