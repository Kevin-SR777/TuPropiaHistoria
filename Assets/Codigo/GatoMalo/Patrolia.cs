using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolia : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime;

    private int currentWaypoint;
    private bool isWaiting;
    
    void Update()
    {
        if(transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

        }
        else if(!isWaiting)
        {
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;
        if(currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }
        isWaiting = false;
                
                
                
    }







}


