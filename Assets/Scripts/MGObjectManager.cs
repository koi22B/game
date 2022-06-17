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
    private float leftside;
    private float rightside;
    private Sequence sequence;
    private float x;
    private int [] action;
    public struct S_default
    {
        public float leftside;
        public float rightside;
        public float dashtime;
        public float dashlen;
        public float sidetime;
        public float lanewidth;
    }
    private S_default s_default;

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
        s_default.leftside = -5f;
        s_default.rightside = 5f;
        s_default.dashtime = 2.5f;
        s_default.dashlen = 4f;
        s_default.sidetime = 0.5f;
        s_default.lanewidth = 1f;
        x = 0f;
        action = new int[4] {0, 1, 2, 3};
    }

    float derivative(float y)
    {
        float n;
        if (y % 6.7f > 3.35f)
        {
            return (0.01f);
        }
        n = x % 2 - 1f;
        x += 0.2f;
        return (n * n / 2);
    }

    void Jump()
    {
        time = 1f + Parameter.param.strength;
        if (dashtime > 0)
        {
            if (time > dashtime)
            {
                time = dashtime;
            }
            if (time > dashtime - s_default.dashtime && dashtime > s_default.dashtime)
            {
                time = dashtime - s_default.dashtime;
            }
        }
        if (sidetime > 0 && time > sidetime)
        {
            time = sidetime;
        }
        Debug.Log("jump");
        sequence.Join(human.DOMoveZ(-1f, time / 2).SetLoops(2,LoopType.Yoyo));
        Parameter.param.strength += derivative(Parameter.param.strength);
    }

    void Dash()
    {
        if (dashtime <= 0)
        {
            Debug.Log("dash");
            sequence.Join(human.DOMoveY(s_default.dashlen, s_default.dashtime).SetLoops(2,LoopType.Yoyo));
            dashtime = s_default.dashtime * 2;
        }
    }

    void Right()
    {
        if (human.position.x < s_default.rightside - s_default.lanewidth && sidetime <= 0)
        {
            Debug.Log("right");
            sequence.Join(human.DOMoveX(human.position.x + s_default.lanewidth, s_default.sidetime).SetEase(Ease.Linear));
            sidetime = s_default.sidetime;
        }
    }

    void Left()
    {
        if (human.position.x > s_default.leftside + s_default.lanewidth && sidetime <= 0)
        {
            Debug.Log("left");
            sequence.Join(human.DOMoveX(human.position.x - s_default.lanewidth, s_default.sidetime).SetEase(Ease.Linear)); 
            sidetime = s_default.sidetime;
        }
    }

    void Action_Select(int n)
    {
        if (n == 0)
        {
            Jump();
        }
        else if (n == 1)
        {
            Dash();
        }
        else if (n == 2)
        {
            Right();
        }
        else if (n == 3)
        {
            Left();
        }
    }

    void Action()
    {
        sequence = DOTween.Sequence();
        if (Input.GetKey(KeyCode.Space))
        {
            Action_Select(action[0]);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Action_Select(action[1]);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Action_Select(action[2]);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Action_Select(action[3]);
        }
        if (dashtime > 0)
        {
            dashtime -= Time.deltaTime;
        }
        if (sidetime > 0)
        {
            sidetime -= Time.deltaTime;
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
            scale = 2 / scale;
        }
        size.x = human_size.x * scale;
        size.y = human_size.y * scale;
        size.z = human_size.z * scale;
        human.localScale = size;
        // scale = (shadow.position - camera.position).magnitude;
        scale = Mathf.Abs(shadow.position.z - cam.position.z);
        if (scale != 0)
        {
            scale = 2 / scale;
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
        Fix_position();
        Fix_size();
    }
}
