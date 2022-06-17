using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MGObjectManager : MonoBehaviour
{
    private Transform basepoint;
    private Transform human;
    private Transform shadow;
    private Transform cam;
    [SerializeField]  private float shadow_tan;
    private Vector3 human_size;
    private Vector3 shadow_size;
    public float time;
    public float dashtime;
    public float sidetime;
    private float lrmove;
    private float lrinterval;
    private float leftside;
    private float rightside;
    private Sequence sequence;

    // Start is called before the first frame update
    void Start()
    {
        basepoint = GameObject.FindGameObjectWithTag("base").transform;
        human = GameObject.FindGameObjectWithTag("human").transform;
        shadow = GameObject.FindGameObjectWithTag("shadow").transform;
        cam = Camera.main.gameObject.transform;
        human_size = human.localScale;
        shadow_size = human.localScale;
        shadow_tan = 0.0f;
        time = 0f;
        dashtime = 0f;
        sidetime = 0f;
        leftside = -5f;
        rightside = 5f;
        lrmove = 0.5f;
        lrinterval = 1f;
    }

    void Action()
    {
        sequence = DOTween.Sequence();
        if (Input.GetKey(KeyCode.Space))
        {
            time = 3f;
            if (dashtime > 0)
            {
                if (time > dashtime)
                {
                    time = dashtime;
                }
                else if (time > dashtime - 2.5f)
                {
                    time = dashtime - 2.5f;
                }
            }
            if (sidetime > 0 && time > sidetime)
            {
                time = sidetime;
            }
            Debug.Log("jump");
            sequence.Join(human.DOMoveZ(-1f, time / 2).SetLoops(2,LoopType.Yoyo));
        }
        if (Input.GetKey(KeyCode.UpArrow) && dashtime <= 0)
        {
            Debug.Log("dash");
            sequence.Join(human.DOMoveY(5f, 2.5f).SetLoops(2,LoopType.Yoyo));
            dashtime = 5f;
        }
        // else if (Input.GetKey(KeyCode.DownArrow))
        // {
        //     Debug.Log("dash");
        // }
        if (Input.GetKey(KeyCode.RightArrow) && human.position.x < rightside - lrinterval && sidetime <= 0)
        {
            Debug.Log("right");
            sequence.Join(human.DOMoveX(human.position.x + lrinterval, lrmove).SetEase(Ease.Linear));
            sidetime = lrmove;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && human.position.x > leftside + lrinterval && sidetime <= 0)
        {
            Debug.Log("left");
            sequence.Join(human.DOMoveX(human.position.x - lrinterval, lrmove).SetEase(Ease.Linear));
            sidetime = lrmove;
        }
    }

    void Fix_position()
    {
        Vector3 pos;
        pos.x = human.position.x;
        pos.y = human.position.y;
        pos.z = basepoint.position.z;
        basepoint.position = pos;
        pos.y = human.position.y + (human.position.z - basepoint.position.z) * shadow_tan - human.localScale.y;
        shadow.position = pos; 
    }

    void Fix_size()
    {
        float scale;
        Vector3 size;

        // scale = (human.position - cam.position).magnitude;
        scale = Mathf.Abs(human.position.z - cam.position.z);
        if (scale != 0)
        {
            scale = 1 / scale;
        }
        size.x = human_size.x * scale;
        size.y = human_size.y * scale;
        size.z = human_size.z * scale;
        human.localScale = size;
        // scale = (shadow.position - camera.position).magnitude;
        scale = Mathf.Abs(shadow.position.z - cam.position.z);
        if (scale != 0)
        {
            scale = 1 / scale;
        }
        size.x = shadow_size.x * scale;
        size.y = shadow_size.y * scale;
        size.z = shadow_size.z * scale;
        shadow.localScale = size;
    }

    void Update()
    {
        if (time <= 0)
        {
            Action();
        }
        else
        {
            time -= Time.deltaTime;
        }
        if (dashtime > 0)
        {
            dashtime -= Time.deltaTime;
        }
        if (sidetime > 0)
        {
            sidetime -= Time.deltaTime;
        }
        Fix_position();
        Fix_size();
    }
}
