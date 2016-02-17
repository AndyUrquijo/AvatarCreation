using UnityEngine;
using System.Collections;

public class SendMouseEventsToParent : MonoBehaviour 
{
    public string MouseDown;
    public string MouseUp;


    void OnMouseDown()
    {
        if(MouseDown != "")
            transform.parent.gameObject.SendMessage(MouseDown);
    }
    void OnMouseUp()
    {
        if(MouseUp != "")
            transform.parent.gameObject.SendMessage(MouseUp);
    }
}
