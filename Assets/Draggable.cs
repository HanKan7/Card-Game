using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour , IBeginDragHandler , IDragHandler , IEndDragHandler
{
    public Transform parentToReturnTo = null;
    //public enum Slot { WEAPON, HEAD, CHEST, LEGS, FEET };
    //public Slot type = Slot.WEAPON;
    GameObject placeHolder = null;


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;

        placeHolder.transform.SetSiblingIndex(transform.GetSiblingIndex());

        
        parentToReturnTo = this.transform.parent;
        //this.transform.parent = transform.parent.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag");
        transform.position = eventData.position;


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        Destroy(placeHolder);
        //this.transform.parent = parentToReturnTo;
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
