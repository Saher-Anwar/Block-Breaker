using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float MinX = 1f;
    [SerializeField] float MaxX = 15f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MousePosInUnits = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        Vector2 PaddePos = new Vector2(transform.position.x, transform.position.y);
        PaddePos.x = Mathf.Clamp(MousePosInUnits, MinX, MaxX);
        transform.position = PaddePos;
    }
}
