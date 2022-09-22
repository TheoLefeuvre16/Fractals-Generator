using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explorer : MonoBehaviour
{
    public Material mat;
    public Vector2 pos;
    public float scale,angle;

    private Vector2 smoothPos;
    private float smoothScale;
    private float smoothAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void UpdateShader()
    {
        smoothPos = Vector2.Lerp(smoothPos, pos, .03f);
        smoothScale = Mathf.Lerp(smoothScale, scale, .03f);
        smoothAngle = Mathf.Lerp(smoothAngle, angle, .03f);
        float aspect = (float)Screen.width / (float)Screen.height;

        float scaleX = smoothScale;
        float scaleY = smoothScale;

        if (aspect > 1)
            scaleY /= aspect;
        else
            scaleX *= aspect;
        mat.SetVector("_Area", new Vector4(smoothPos.x, smoothPos.y, scaleX, scaleY));
        mat.SetFloat("_Angle", smoothAngle);
    }
    private void HandleInputs()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
            scale *= 0.99f;
        if(Input.GetKey(KeyCode.KeypadMinus))
            scale *= 1.01f;
        if (Input.GetKey(KeyCode.Q))
            pos.x -= .01f * scale;
        if (Input.GetKey(KeyCode.D))
            pos.x += .01f * scale;

        if (Input.GetKey(KeyCode.Z))
            pos.y += .01f * scale;

        if (Input.GetKey(KeyCode.S))
            pos.y -= .01f * scale;

        if (Input.GetKey(KeyCode.A))
            angle -= .01f;

        if (Input.GetKey(KeyCode.E))
            angle += .01f;


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        HandleInputs();
        UpdateShader();
    }
}
