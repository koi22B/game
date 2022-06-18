using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGHumanTrigger : MonoBehaviour
{
    private string[] item = new string[3]{"item0", "item1", "item2"};
    void GetItem(int i)
    {

    }

    void HitHurdle()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        int i;
        for (i = 0; i < 3; i++)
        {
            if (string.Compare(other.gameObject.tag, item[i]) == 0)
            {
                Debug.Log(item[i]);
                GetItem(i);
                other.gameObject.SetActive(false);
            }
        }
        if (string.Compare(other.gameObject.tag, "hurdle") == 0)
        {
            HitHurdle();
            other.gameObject.SetActive(false);
        }
    }
}
