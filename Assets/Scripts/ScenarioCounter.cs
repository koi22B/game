using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioCounter : MonoBehaviour
{
    private static ScenarioCounter instance;
    public static ScenarioCounter Instance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    [SerializeField]
    private int count = 0;
    public void incScenario()
    {
        count++;
    }
    public int getCount()
    {
        return count;
    }
}
