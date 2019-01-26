using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    private Transform tr;
    private Transform playerTr;
    private Vector3 setups;

    public float cameraDampingHorizen = 1.0f;
    public float cameraDampingVertical = 1.0f;
    [Header("Camera Outline")]
    public float limitYdown;
    public float limitYup;
    public float limitXleft;
    public float limitXright;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        setups = new Vector3(0f, 0f, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        var currentX = tr.position.x;
        var wantedX = playerTr.position.x;
        
        var currentY = tr.position.y;
        var wantedY = playerTr.position.y;

        if (wantedX < limitXleft)
        {
            wantedX = limitXleft;
        }
        else if (wantedX > limitXright)
        {
            wantedX = limitXright;
        }

        if (wantedY < limitYdown)
        {
            wantedY = limitYdown;
        }
        else if(wantedY>limitYup)
        {
            wantedY = limitYup;
        }
        currentX = Mathf.Lerp(currentX, wantedX, cameraDampingHorizen * (float)Time.deltaTime);
        currentY = Mathf.Lerp(currentY, wantedY, cameraDampingVertical * (float)Time.deltaTime);
        tr.position = new Vector3(currentX,currentY,-10);


    }
}
