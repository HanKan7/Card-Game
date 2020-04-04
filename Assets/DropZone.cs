using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour , IDropHandler , IPointerEnterHandler , IPointerExitHandler
{
    //public Draggable.Slot type = Draggable.Slot.CHEST;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();

        if(draggable != null)
        {
            //if(type == draggable.type) 
            draggable.parentToReturnTo = this.transform;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("On pointer Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("On pointer Exit");
    }
}
