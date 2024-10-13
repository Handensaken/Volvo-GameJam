using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonStandOn : MonoBehaviour
{
    public float range = 1f;
    public LayerMask layerMask;
    [Header("Door Stuff")]
    public Transform door;
    public Transform doorOpen;
    public Transform doorClose;
    public float speed = 2f;

    private Coroutine moveDoorCoroutine;

    void Update()
    {
        GetComponent<Renderer>().material.color = Color.red;

        Collider2D colliders = Physics2D.OverlapCircle(transform.position, range, layerMask);
        if (colliders != null)
        {
            if (Vector3.Distance(door.position, doorOpen.position) > 0.01f)
            {
                door.position = Vector3.MoveTowards(door.position, doorOpen.position, speed * Time.deltaTime);
                GetComponent<Renderer>().material.color = Color.green; 
            }
            else
            {
                door.position = doorOpen.position; 
            }
        }
        else
        {
            if (Vector3.Distance(door.position, doorClose.position) > 0.01f)
            {
                door.position = Vector3.MoveTowards(door.position, doorClose.position, speed * Time.deltaTime);
                GetComponent<Renderer>().material.color = Color.red; 
            }
            else
            {
                door.position = doorClose.position;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
