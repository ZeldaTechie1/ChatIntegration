using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    //These are non-adjustble variables
    float resetTime = 10f;
    float resetTimer = 0;
    float defaultActivationTime = 0.5f;
    float defaultSpikeSize = 1;
    Vector3 defaultSpikePosition;
    public GameObject spikes;
    bool isActivated;

    //These are adjustable trap variables
    public float activationTime;
    public float spikeSize;

    void Start()
    {
        activationTime = defaultActivationTime;
        spikeSize = defaultSpikeSize;
        defaultSpikePosition = spikes.transform.position;
        isActivated = false;
    }

    void Update()
    {
        if(resetTimer > 0)
        {
            resetTimer -= Time.deltaTime;
            if(resetTimer <= 0)
            {
                Reset();
            }
        }

        spikeSize = Mathf.Clamp(spikeSize,defaultSpikeSize,2);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player" && !isActivated)
        {
            ActivateTrap();
        }
    }

    void ActivateTrap()
    {
        isActivated = true;
        MoveSpikes();
        resetTimer = resetTime;
    }

    void Reset()
    {
        activationTime = defaultActivationTime;
        spikeSize = defaultSpikeSize;
        spikes.transform.position = defaultSpikePosition;
        resetTimer = 0;
        isActivated = false;
    }

    void MoveSpikes()
    {
        Vector3 newPosition = spikes.transform.position;
        newPosition.y += spikeSize;
        spikes.transform.position = newPosition;
    }
}
