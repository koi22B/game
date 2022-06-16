using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] int inorout; //in: 1 out: -1
    [SerializeField] Image img;
    [SerializeField] float fadeSpeed;
    Color c;
    // Start is called before the first frame update
    void Start()
    {
        c = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (c.a < 1.0001f || c.a >= 0.0f)
        {
            c.a += inorout * fadeSpeed * Time.deltaTime;
            img.color = c;
        }
        if(this.gameObject.activeSelf && c.a <= 0.0f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
