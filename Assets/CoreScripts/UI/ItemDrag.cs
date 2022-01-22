using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Button拖拽功能
public class ItemDrag : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
{
	private Vector3 origin;
	//存储当前拖拽图片的RectTransform组件
	private RectTransform rect;
	void Start()
	{
		rect = gameObject.GetComponent<RectTransform>();
		origin = transform.localPosition;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		print("click" + gameObject.name);
	}

	public void OnDrag(PointerEventData eventData)
	{
		SetDraggedPosition(eventData);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		print(eventData.pointerCurrentRaycast.gameObject.name);
		if (eventData.pointerCurrentRaycast.gameObject.tag != "EventObj")
		{
			transform.localPosition = origin;
		}
	}

	private void SetDraggedPosition(PointerEventData eventData)
	{
		Vector3 globalMousePos;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out globalMousePos))
		{
			rect.position = globalMousePos;
		}
	}
}