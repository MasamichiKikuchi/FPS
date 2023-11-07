using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�ړ����x
    private float movespeed = 3;

    private Vector3 moveVelocity;

    private CharacterController characterController;
    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //���͎��ɂ��ړ�����
        moveVelocity.x = Input.GetAxis("Horizontal") * movespeed;
        moveVelocity.z = Input.GetAxis("Vertical") * movespeed;

        characterController.Move(moveVelocity);
    }
}
