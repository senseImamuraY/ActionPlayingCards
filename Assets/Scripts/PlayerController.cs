using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce, gravityScale;
    private float yStore;

    public CharacterController charCon;

    private CameraController cam;

    private Vector3 moveAmount;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        yStore = moveAmount.y;

        moveAmount = (cam.transform.forward * Input.GetAxisRaw("Vertical")) + (cam.transform.right * Input.GetAxisRaw("Horizontal"));

        moveAmount.y = 0f;

        moveAmount = moveAmount.normalized;

        moveAmount.y = yStore;

        if (charCon.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveAmount.y = jumpForce;
            }
        }

        //charCon.Move(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, 0f, Input.GetAxisRaw("Vertical") * moveSpeed) * Time.deltaTime);
        charCon.Move(new Vector3(moveAmount.x * moveSpeed, moveAmount.y, moveAmount.z * moveSpeed)* Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (!charCon.isGrounded)
        {
            moveAmount.y = moveAmount.y + (Physics.gravity.y * gravityScale * Time.fixedDeltaTime);
    }
        else
        {
            //í[Ç…Ç¢ÇÈÇ∆Ç´ÅAínñ Ç…í@Ç´Ç¬ÇØÇÁÇÍÇÈÇÊÇ§Ç»ãììÆÇ…Ç»ÇÁÇ»Ç¢ÇÊÇ§Ç…Ç∑ÇÈÇΩÇﬂÇ…í«â¡
            moveAmount.y = Physics.gravity.y* gravityScale * Time.deltaTime;
        }
    }
}
