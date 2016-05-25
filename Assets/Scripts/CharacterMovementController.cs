using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovementController : MonoBehaviour {

    //inspector variables
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private float speed;


    //private variables
    private float verticalInput;
    private float horizontalInput;
    private NavMeshAgent navMeshAgent;
    private Vector3 lookingPosition;
    private NetworkIdentity networkIdentity;


    protected virtual void Awake() {
        if (mainCamera == null) mainCamera = Camera.main;

        navMeshAgent = GetComponent<NavMeshAgent>();
        networkIdentity = GetComponent<NetworkIdentity>();
    }

    // Use this for initialization
    /*protected virtual, caso criar classe que tenha essa como base
    **poder reescrever os métodos
    */
    protected virtual void Start() {

    }

    // Update is called once per frame
    protected virtual void Update() {
        if (!networkIdentity.isLocalPlayer) return;
        DetectInput();
        MoveCharacter();
        LookToPointer();
    }

    private void LookToPointer() {
        Quaternion lookRotation = Quaternion.LookRotation(lookingPosition-transform.position, transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, speed*Time.deltaTime);
    }

    private void MoveCharacter() {
        Debug.Log(speed);
        Debug.Log(horizontalInput);
        Debug.Log(verticalInput);

        Vector3 targetPosition = new Vector3(horizontalInput*speed, 0,verticalInput*speed);
        navMeshAgent.Move(targetPosition * Time.deltaTime);
    }

    private void DetectInput() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Ray cameraToGround = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(cameraToGround, out hit, 50.0f, groundLayer)) {
            lookingPosition = hit.point;
        }

    }
}
