using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Selected : MonoBehaviour
{
    private Vector3 defaultPos;
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        defaultPos = transform.position;
    }
    //　押された時
    private void OnMouseDown()
    {
        text.text = "AA";
    }
    //　入ってきた時
    private void OnMouseEnter()
    {
    }
    //　出ていったとき
    private void OnMouseExit()
    {
    }
    //　上にいる時
    private void OnMouseOver()
    {
        Debug.Log("OnMouseOver");
    }
    //　離した時
    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
    }
    //　オブジェクト上で話した時
    private void OnMouseUpAsButton()
    {
        Debug.Log("OnMouseUpAsButton");
    }
}
