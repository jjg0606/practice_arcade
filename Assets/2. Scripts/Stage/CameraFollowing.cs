using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    private Transform tr;
    private Transform playerTr;
    private Vector3 setups;
    private float cameraCali=1.5f;

    public float cameraDampingHorizen = 1.0f;
    public float cameraDampingVertical = 1.0f;
    [Header("Camera Outline")]
    public Transform limitYdown;
    public Transform limitYup;
    public Transform limitXleft;
    public Transform limitXright;
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
        var wantedY = playerTr.position.y+cameraCali;

        if (wantedX < limitXleft.position.x)
        {
            wantedX = limitXleft.position.x;
        }
        else if (wantedX > limitXright.position.x)
        {
            wantedX = limitXright.position.x;
        }

        if (wantedY < limitYdown.position.y)
        {
            wantedY = limitYdown.position.y;
        }
        else if(wantedY>limitYup.position.y)
        {
            wantedY = limitYup.position.y;
        }
        currentX = Mathf.Lerp(currentX, wantedX, cameraDampingHorizen * (float)Time.deltaTime);
        currentY = Mathf.Lerp(currentY, wantedY, cameraDampingVertical * (float)Time.deltaTime);
        tr.position = new Vector3(currentX,currentY,-10);


    }
}
