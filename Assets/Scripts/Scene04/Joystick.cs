using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    public Vector2 joystickTouchPos;
    public Vector2 joystickOriginPos;
    public float joystickRadius;
    // Start is called before the first frame update
    void Start()
    {
        joystickOriginPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginPos;
        joystickBG.transform.position = joystickOriginPos;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;

        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;
        float joystickDict = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDict < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDict;

        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }    

    }
}
