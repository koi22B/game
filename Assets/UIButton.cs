using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIButton : MonoBehaviour
{
    public bool clicked = false;
    public GameObject button1;
    public GameObject button2;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    
    int ans = -1;

    public void Start () {
        button1.SetActive(false);
        button2.SetActive(false);
    }

    public void ButtonClick(int number) {
        switch (number) {
        case 1:
            clicked = true;
            ans = 1;
            break;
        case 2:
            clicked = true;
            ans = 2;
            break;
        default:
            break;
        }
    }

    public void DrawButton(string s1, string s2) {
        button1.SetActive(true);
        button2.SetActive(true);
        text1.text = s1;
        text2.text = s2;
    }

    public int GetButton() {
        if(clicked){
            Debug.Log("ボタン消すよ");
            clicked = false;
            button1.SetActive(false);
            button2.SetActive(false);
            return ans;
        }
        else {
            return -1;
        }
    }
}
