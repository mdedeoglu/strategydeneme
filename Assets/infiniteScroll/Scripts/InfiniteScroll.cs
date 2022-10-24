using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour, IBeginDragHandler, IDragHandler, IScrollHandler
{
    #region Private Members

    /// <summary>
    /// The ScrollContent component that belongs to the scroll content GameObject.
    /// </summary>
    [SerializeField]
    private ScrollContent scrollContent;

    /// <summary>
    /// How far the items will travel outside of the scroll view before being repositioned.
    /// </summary>
    [SerializeField]
    private float outOfBoundsThreshold;

    /// <summary>
    /// The ScrollRect component for this GameObject.
    /// </summary>
    private ScrollRect scrollRect;

    /// <summary>
    /// The last position where the user has dragged.
    /// </summary>
    private Vector2 lastDragPosition;

    /// <summary>
    /// Is the user dragging in the positive axis or the negative axis?
    /// </summary>
    private bool positiveDrag;

    #endregion

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        //scrollRect.vertical = scrollContent.Vertical;
        //scrollRect.horizontal = scrollContent.Horizontal;
        scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
    }

    /// <summary>
    /// Called when the user starts to drag the scroll view.
    /// </summary>
    /// <param name="eventData">The data related to the drag event.</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        lastDragPosition = eventData.position;
    }

    /// <summary>
    /// Called while the user is dragging the scroll view.
    /// </summary>
    /// <param name="eventData">The data related to the drag event.</param>
    public void OnDrag(PointerEventData eventData)
    {
        
            positiveDrag = eventData.position.y > lastDragPosition.y;
        
     
        lastDragPosition = eventData.position;
    }

    /// <summary>
    /// Called when the user starts to scroll with their mouse wheel in the scroll view.
    /// </summary>
    /// <param name="eventData">The data related to the scroll event.</param>
    public void OnScroll(PointerEventData eventData)
    {
        positiveDrag = eventData.scrollDelta.y < 0;
        
    }

    /// <summary>
    /// Called when the user is dragging/scrolling the scroll view.
    /// </summary>
    public void OnViewScroll()
    {
        
        HandleVerticalScroll();
        
       
    }

    /// <summary>
    /// Called if the scroll view is oriented vertically.
    /// </summary>
    private void HandleVerticalScroll()
    {
        int currItemIndex = positiveDrag ? 0: scrollRect.content.childCount - 1;
        var currItem = scrollRect.content.GetChild(currItemIndex);
    
        if (!ReachedThreshold(currItem))
        {
            return;
        }

        int endItemIndex = positiveDrag ? scrollRect.content.childCount - 1:0;
        Transform endItem = scrollRect.content.GetChild(endItemIndex);
        Vector2 newPos = endItem.position;
        float posOffset = scrollContent.ChildHeight * 0.5f;
        newPos.x = currItem.position.x;
        Debug.Log(newPos.x.ToString());
        Debug.Log(newPos.x);
        if (positiveDrag)
        {

            if (int.Parse(currItem.name) % 2 == 0)
            {
                newPos.y = endItem.position.y - scrollContent.ChildHeight * 1.5f - scrollContent.ItemSpacing + posOffset;
            }
            else
            {
                newPos.y = endItem.position.y;
            }
        }
        else
        {
            if (int.Parse(currItem.name) % 2 != 0)
            {
                newPos.y = endItem.position.y + scrollContent.ChildHeight * 1.5f + scrollContent.ItemSpacing - posOffset;
            }
            else
            {
                newPos.y = endItem.position.y;// + scrollContent.ChildHeight * 1.5f + scrollContent.ItemSpacing - posOffset;
            }
        }
        currItem.position = newPos;
        currItem.SetSiblingIndex(endItemIndex);
        
    }

    
    /// <summary>
    /// Checks if an item has the reached the out of bounds threshold for the scroll view.
    /// </summary>
    /// <param name="item">The item to be checked.</param>
    /// <returns>True if the item has reached the threshold for either ends of the scroll view, false otherwise.</returns>
    private bool ReachedThreshold(Transform item)
    {  
            float posYThreshold = transform.position.y + scrollContent.Height * 0.5f + outOfBoundsThreshold;
            float negYThreshold = transform.position.y - scrollContent.Height * 0.5f - outOfBoundsThreshold;
            //Debug.Log(item.name+" pos:"+posYThreshold.ToString()+" neg:"+negYThreshold.ToString());

            return positiveDrag ? item.position.y + scrollContent.ChildWidth * 0.5f > posYThreshold :
               item.position.y - scrollContent.ChildWidth * 0.5f < negYThreshold;   
       
    }
}
