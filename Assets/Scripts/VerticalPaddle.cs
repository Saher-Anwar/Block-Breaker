using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPaddle : MonoBehaviour
{
    // config parameters (tuning and settings before the game eg: health, audio, etc)
    [SerializeField] float ScreenHeightSize = 12f;
    [SerializeField] float MinY = 1f;
    [SerializeField] float MaxY = 11f;

    // cached references (references to game objects, components, etc)


    // state variables (keep track of variables)


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float YMousePosInUnits = Input.mousePosition.y / Screen.height * ScreenHeightSize;
        Vector2 VerticalPaddlePos = new Vector2(transform.position.x, transform.position.y);
        VerticalPaddlePos.y = Mathf.Clamp(YMousePosInUnits, MinY, MaxY);
        transform.position = VerticalPaddlePos;
    }
}
