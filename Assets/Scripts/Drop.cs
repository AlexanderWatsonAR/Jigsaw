﻿using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour , IDropHandler
{
	// This value shows the maximum number of children that can be dropped onto this game object.
	public int MaximumNumberOfChildren; 

	public bool AtMaxChildNumber
	{
		get
		{
			if(transform.childCount == MaximumNumberOfChildren)
				return true;
			return false;
		}
	}

	#region IdropHandler implementation
	public void OnDrop(PointerEventData eventData)
	{
        // if the child count is not at maximum and the tags match then dragged item is made a child of this game object.
        if (!AtMaxChildNumber && tag == "Untagged" && Drag.ItemBeingDragged.tag == "Untagged")
        {
            Drag.ItemBeingDragged.transform.SetParent(transform);
            Drag.ItemBeingDragged.GetComponent<Drag>().startParent = transform;
            Drag.ItemBeingDragged.GetComponent<Drag>().startPosition = Vector3.zero;
            Drag.ItemBeingDragged.transform.localPosition = Vector3.zero;
            if (GetComponent<CheckCorrectPiece>() != null)
                GetComponent<CheckCorrectPiece>().CheckPiece();
        }
        if (!AtMaxChildNumber && this.tag == Drag.ItemBeingDragged.tag)
        {
            Drag.ItemBeingDragged.transform.SetParent(transform);
            Drag.ItemBeingDragged.GetComponent<Drag>().startParent = transform;
            Drag.ItemBeingDragged.GetComponent<Drag>().startPosition = Vector3.zero;
            Drag.ItemBeingDragged.transform.localPosition = Vector3.zero;
            if (GetComponent<CheckCorrectPiece>() != null)
                GetComponent<CheckCorrectPiece>().CheckPiece();
        }
	}
	#endregion
}﻿