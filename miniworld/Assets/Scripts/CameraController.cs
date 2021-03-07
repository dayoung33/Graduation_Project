using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rotateSpeedX = 3.0f;
    private float rotateSpeedY = 3.0f;
    private float limitMinX = -80.0f;
    private float limitmaxX = 50.0f;
    private float eulerAngleX;
    private float eulerAngleY;

    public void RotateTo(float mouseX, float mouseY)
    {
        //마우스를 좌우로 움직이는 마우스 x값을 y축에 대입하는 이유는 카메라의 y축이 회전되어야하기 때문
        eulerAngleY += mouseX * rotateSpeedX;

        eulerAngleX -= mouseY * rotateSpeedY;

        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitmaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }

    private float ClampAngle(float angle,float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
