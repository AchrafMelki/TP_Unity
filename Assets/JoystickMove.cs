using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoystickMove : MonoBehaviour
{
    public GameObject joystick;

    public GameObject joystickBG;

    public Vector2 joystickVector;

    public Vector2 joystickTouchPos;

    public Vector2 joystickStartPos;

    public float joystickRadius;
    // Start is called before the first frame update
    void Start()
    {
        joystickStartPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }

    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = new Vector3(Input.mousePosition.x-45f,Input.mousePosition.y-45f,Input.mousePosition.z);
        joystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVector = (dragPos - joystickTouchPos).normalized;
        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVector * joystickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVector * joystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVector = Vector2.zero;
        joystick.transform.position = new Vector3(joystickStartPos.x+45f,joystickStartPos.y+45f);
        joystickBG.transform.position = joystickStartPos;
    }
    
}