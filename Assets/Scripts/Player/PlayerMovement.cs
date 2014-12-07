using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region fields 
    public float moveSpeed = 6.0f;

    private Vector3 movement;
    private Rigidbody playerRigidbody;
    private int floorMask;
    private float camRayLenght = 100.0f;

    private float speedTimer = 10f;
    #endregion

    #region Awake
    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
    }
    #endregion

    #region FixedUpdate
    void FixedUpdate()
    {
        float hoz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        Move(hoz, vert);
        Turn();
    }
    #endregion

    #region Move
    void Move(float hoz, float vert)
    {
        movement.Set(hoz, 0f, vert);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }
    #endregion

    #region Turn
    void Turn()
    {
        Ray CamRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(CamRay, out floorHit, camRayLenght, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }
    #endregion

    void Update()
    {
        if(moveSpeed > 6)
        {
            if(speedTimer > 0)
            {
                speedTimer -= Time.deltaTime;
            }

            if(speedTimer <= 0)
            {
                moveSpeed = 6;
                speedTimer = 10;
            }
        }

    }
}
