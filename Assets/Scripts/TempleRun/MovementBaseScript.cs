using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBaseScript : MonoBehaviour
{
    [SerializeField]
    PathCreator pathCreator;

    float speed = 6f;
    Vector3 endPos;

    float moveDistance;

    void Start()
    {
        endPos = pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1);
    }

    void Update()
    {
        moveDistance += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(moveDistance, EndOfPathInstruction.Stop);
        transform.rotation = pathCreator.path.GetRotationAtDistance(moveDistance, EndOfPathInstruction.Stop);
    }
}