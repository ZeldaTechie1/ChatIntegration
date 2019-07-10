using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{

    //These are not adjustable variables
    float defaultRotationSpeed = 400f;
    float defaultHammerHeadSize = 1f;
    public GameObject hammerHead;

    //These are adjustable variables
    public float rotationSpeed;
    public float hammerHeadSize;

    void Update()
    {
        this.transform.Rotate(rotationSpeed*Time.deltaTime,0,0,Space.Self);
        hammerHead.transform.localScale = new Vector3(hammerHeadSize,hammerHeadSize,hammerHeadSize * 2.1f);
        rotationSpeed = Mathf.Clamp(rotationSpeed,defaultRotationSpeed,700);
        hammerHeadSize = Mathf.Clamp(hammerHeadSize, defaultHammerHeadSize, 7);
    }

    void Reset()
    {

    }

}
