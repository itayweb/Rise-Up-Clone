using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SummonCursor();
    }

    void SummonCursor()
    {
        if (GameObject.FindGameObjectWithTag("Cursor"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Cursor"));
        }
        GameObject test = Instantiate(cursor) as GameObject;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        test.transform.position = pos;
    }
}
