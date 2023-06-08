using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour//It makes moveing background
{
    public float speed = 10f;

    public List<Transform> backgrounds = new List<Transform>();



    Vector3 startPos;
    Vector3 endPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = backgrounds[0].position;
        endPos = backgrounds[backgrounds.Count - 1].position;
    }

    // Update is called once per frame
    void Update()
    {
        //move background
        foreach(Transform background in backgrounds)
        {
            background.position = background.position + Vector3.down * speed * Time.deltaTime;
        }

        if(backgrounds[backgrounds.Count - 1].position.y <= endPos.y)
        {
            backgrounds[backgrounds.Count - 1].position = startPos;

            Transform temp = backgrounds[backgrounds.Count - 1];
            backgrounds.RemoveAt(backgrounds.Count - 1);
            backgrounds.Insert(0, temp);
        }
    }
}
