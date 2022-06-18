using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIButton : MonoBehaviour
{
    bool clicked = false;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    
    int ans = -1;

    public void Start () {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        button5.SetActive(false);
    }

    public void ButtonClick(int number) {
        clicked = true;
        ans = number;
    }

    public void DrawButton(List<string> texts) {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);
        button5.SetActive(true);
        text1.text = texts[0];
        text2.text = texts[1];
        text3.text = texts[2];
        text4.text = texts[3];
        text5.text = texts[4];
    }

    public int GetButton() {
        if(clicked){
            //Debug.Log("ボタン消すよ");
            clicked = false;
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            button5.SetActive(false);
            return ans;
        }
        else {
            return -1;
        }
    }
}
