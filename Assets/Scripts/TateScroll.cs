using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TateScroll : MonoBehaviour
{

    // スクロールスピードをここで定義
    [SerializeField] float speed = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //下方向にスクロール
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Yが-11まで来れば、21.33まで移動する
        if (transform.position.y <= -2.95f)
        {
            transform.position = new Vector2(0, 10.4f);
        }
    }
}
