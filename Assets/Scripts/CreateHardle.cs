using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHardle : MonoBehaviour
{
    public GameObject makeprefab;
    private const float START = 0.0f;
    private const float INTERVAL = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateMakePrefab", START, INTERVAL);
    }
    private void UpdateMakePrefab() {
        float x = Mathf.Floor(Random.Range(1, 5));
        x -= 2.5f;
        x *= 5f;
        Vector3 pos = new Vector3(x, 10.0f, 0);
        Instantiate(makeprefab, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
