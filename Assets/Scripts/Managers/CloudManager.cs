using UnityEngine;
using System.Collections;

public class CloudManager : MonoBehaviour
{

    public Vector3 startPoint;
    public Transform target;
    public float moveSpeed;

    void Start()
    {
        startPoint = transform.position;
    }

    void Update()
    {
        float step = moveSpeed * Time.deltaTime;

        if (transform.position.x != target.position.x)
        {
            //transform.position = new Vector3(transform.position.x * Time.deltaTime * -moveSpeed,
            //    transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

        else if(transform.position.x == target.position.x)
        {
            transform.position = startPoint;
        }
    }
}
