using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private enum Selector
    {
        Start,
        Exit,
        End
    };

    [SerializeField] private List<GameObject> Selectors;

    int tmpId = (int)Selector.Start;


    void Select(int id)
    {
        for(int i=0;i<Selectors.Count;i++)
        {
            Selectors[i].SetActive(false);
        }
        Selectors[id].SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Select(tmpId);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            tmpId++;
            tmpId %= (int)Selector.End;
            Select(tmpId);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            tmpId--;
            tmpId += (int)Selector.End;
            tmpId %= (int)Selector.End;
            Select(tmpId);
        }
    }
}
