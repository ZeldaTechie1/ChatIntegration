using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{

    //These variables are not adjustable
    float launchTimer = 0f;
    float defaultTimeToLaunch = 10f;
    public float launchDistance;
    Vector3 defaultPosition;
    bool isActivated = false;
    Vector3 targetPosition;

    //These variables are adjustable
    public float timeToLaunch;

    void Start()
    {
        timeToLaunch = defaultTimeToLaunch;
        defaultPosition = transform.position;
        targetPosition = transform.position + (this.transform.right * -launchDistance);
        Reset();
    }

    void Update()
    {
        timeToLaunch = Mathf.Clamp(timeToLaunch,1,defaultTimeToLaunch);
        if(launchTimer >0)
        {
            launchTimer -= Time.deltaTime;
            if(launchTimer<=0)
            {
                ActivateTrap();
            }
        }
        if(isActivated)
        {
            transform.position = Vector3.Lerp(transform.position,targetPosition, 20*Time.deltaTime);//smooths out movement
            if(Vector3.Distance(transform.position,targetPosition) < 0.01)
            {
                isActivated = false;
                Reset();
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, defaultPosition, 20 * Time.deltaTime);//smooths out movement
        }

    }

    void ActivateTrap()
    {
        isActivated = true;
    }

    void Reset()
    {
        launchTimer = timeToLaunch;
    }

}
