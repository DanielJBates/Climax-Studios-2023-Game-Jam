using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField]
    int aiId;
    int pathIndex = 0;
    Transform route;
    Transform currentGoal;

    Rigidbody2D rigidBody;

    [SerializeField]
    [Range(1f, 10f)]
    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        var allPaths = GameObject.Find("AIPaths");
        route = allPaths.transform.GetChild(aiId);
        currentGoal = route.GetChild(pathIndex);
        rigidBody = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentGoal.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, currentGoal.position) < 0.5f)
        {
            NextTargetPosition();
        }
    }

    void NextTargetPosition()
    {
        pathIndex++;
        if (pathIndex >= route.childCount) { pathIndex = 0; }
        currentGoal = route.GetChild(pathIndex);
    }
}
