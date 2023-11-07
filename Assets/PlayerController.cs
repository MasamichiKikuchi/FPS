using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�ړ����x
    public float moveSpeed = 5.0f;
    //�}�E�X(���_)���x
    public float sensitivity = 2.0f;

    private CharacterController controller;
    private float rotationX = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        
        //�}�E�X�J�[�\������ʓ��Ƀ��b�N
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // �L�[�̓��͎����擾
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //���͂����[���h���W���烍�[�J�����W�ɕϊ�
        Vector3 moveDirection = transform.TransformDirection(new Vector3(horizontal, 0, vertical) * moveSpeed);
        //�t���[�����[�g����
        controller.Move(moveDirection * Time.deltaTime);

        // �}�E�X�̓��͎����擾
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        //�}�E�X��Y���ړ����㉺���_�ړ��ɕϊ�
        rotationX -= mouseY;
        //�㉺�̎��_�ړ��𐧌�
        rotationX = Mathf.Clamp(rotationX, -90, 90);


        //�J�����̏㉺��]�𐧌�
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        //�v���C���[�̐�����]�𐧌�
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }
}
