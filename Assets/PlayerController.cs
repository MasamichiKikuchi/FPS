using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour , IDamageable
{
    //移動速度
    public float moveSpeed = 5.0f;
    //ジャンプ力
    public float jumpPower = 3.0f;
    //マウス(視点)感度
    public float sensitivity = 2.0f;

    private CharacterController controller;
    private float rotationX = 0;

    private Vector3 vector3;
    private Transform _transform;

    [SerializeField] int maxLife = 10;
    [SerializeField] int life;


    public GameObject lifeGauge;
    public GameObject panel;

    public AudioClip damageSE;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        life = maxLife;

        controller = GetComponent<CharacterController>();
        _transform = transform;

        //マウスカーソルを画面内にロック
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        // キーの入力軸を取得
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //入力をワールド座標からローカル座標に変換
        Vector3 moveDirection = transform.TransformDirection(new Vector3(horizontal, 0, vertical) * moveSpeed);
        if (Input.GetButtonDown("Jump"))
        {
           vector3.y = jumpPower;
        }
        else
        {
            vector3.y += Physics.gravity.y * Time.deltaTime;
        }


        //フレームレート調整
        controller.Move(moveDirection * Time.deltaTime);
        controller.Move(vector3 * Time.deltaTime);
        // マウスの入力軸を取得
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        //マウスのY軸移動を上下視点移動に変換
        rotationX -= mouseY;
        //上下の視点移動を制限
        rotationX = Mathf.Clamp(rotationX, -90, 90);


        //カメラの上下回転を制御
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        //プレイヤーの水平回転を制御
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);

       
    }
    public void Damage(int damage)
    {
        audioSource.PlayOneShot(damageSE);
        life -= damage;
        Debug.Log($"プレイヤーのライフ{life}");
        lifeGauge.GetComponent<Image>().fillAmount -= 0.2f;
        
        StartCoroutine(ChangeColorOverTime());

        if (life == 0)
        {
            Debug.Log("ゲームオーバー");
        }
    }

    IEnumerator ChangeColorOverTime()
    {
        panel.GetComponent<Image>().color = new Color(1, 0, 0, 0.5f);
        float elapsedTime = 0f;

        while (true)
        {
          yield return new WaitForSeconds(0.5f);
          break;

        }

        panel.GetComponent<Image>().color = Color.clear;
    }   
}
