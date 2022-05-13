using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 3f;
    public GameObject waypointLeft;
    public GameObject waypointRight;
    private Vector2 targetLeft;
    private Vector2 targetRight;
    private float step;
    private Vector2 farLeft;
    private Vector2 farRight;

    private void Start()
    {
        targetLeft = waypointLeft.transform.position;
        targetRight = waypointRight.transform.position;
        step = speed * Time.deltaTime;
        farLeft = new Vector2(targetLeft.x-1, targetLeft.y);
        farRight = new Vector2(targetRight.x+1, targetRight.y);
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x == 1)
            GoLeft();
        else
            GoRight();
        if (transform.position.x <= targetLeft.x)
            transform.localScale = new Vector2(-1,1);
        if (transform.position.x >= targetRight.x)
            transform.localScale = new Vector2(1, 1);
    }
    void GoLeft()
    {
        transform.position = Vector2.MoveTowards(transform.position, farLeft, step);
    }
    void GoRight()
    {
        transform.position = Vector2.MoveTowards(transform.position, farRight, step);
    }
}
