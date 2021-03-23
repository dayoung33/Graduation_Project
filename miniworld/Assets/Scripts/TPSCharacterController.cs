using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacterController : MonoBehaviour
{
    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm;
    [SerializeField]
    private Transform cam;
    [SerializeField]
    private Transform shield;

    private Movement3D playerMovement;

    private float limitMinX = -10.0f;
    private float limitmaxX = 70.0f;
    private float eulerAngleX;
    public float eulerAngleY;
    float wheel = -0.45f;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        Move();
        Zoom();
    }

    private void Move()
    {
        cameraArm.position = new Vector3(characterBody.transform.position.x, characterBody.transform.position.y + 0.15f, characterBody.transform.position.z);
        shield.position = new Vector3(characterBody.transform.position.x, characterBody.transform.position.y + 0.15f, characterBody.transform.position.z);
    }

    private void LookAround()
    {
        if (Input.GetMouseButton(1))
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            Vector3 camAngle = cameraArm.rotation.eulerAngles;

            eulerAngleX -= mouseDelta.y;
            eulerAngleY += mouseDelta.x;
            eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitmaxX);

            cameraArm.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, camAngle.z);
        }
    }

    void Zoom()
    {
        wheel += Input.GetAxis("Mouse ScrollWheel")*0.3f;
        if (wheel >= -0.2f)
            wheel = -0.2f;
        if (wheel <= -1)
            wheel = -1;

        cam.localPosition = new Vector3(0, 0, wheel);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
