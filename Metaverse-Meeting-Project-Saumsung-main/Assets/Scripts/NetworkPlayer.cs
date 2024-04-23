using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private Vector2 placementArea = new Vector2(-10.0f, 10.0f);

    public override void OnNetworkSpawn()
    {
        //base.OnNetworkSpawn();
        disableClientInput();
    }

    public void disableClientInput() 
    {
        if(IsClient && !IsOwner)
        {
            var clientMoveProvider = GetComponentInChildren<ActionBasedContinuousMoveProvider>();
            var clientTurnProvider = GetComponentInChildren<ActionBasedContinuousTurnProvider>();
            var clientControllers = GetComponentsInChildren<ActionBasedController>();
            var clientHead = GetComponentInChildren<TrackedPoseDriver>();
            var clientCamera = GetComponentInChildren<Camera>();

            Debug.Log(clientCamera);

            clientCamera.enabled = false;
            clientMoveProvider.enabled = false;
            clientTurnProvider.enabled = false;
            clientHead.enabled = false;

            foreach(var controller in clientControllers)
            {
                controller.enableInputActions = false;
                controller.enableInputTracking = false;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        if(IsClient && IsOwner)
        {
            transform.position = new Vector3(Random.Range(placementArea.x,placementArea.y),transform.position.y,
                Random.Range(placementArea.x,placementArea.y));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
