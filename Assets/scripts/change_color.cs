using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;

public class change_color : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Text StartText;

	public void OnPointerEnter(PointerEventData eventData)
	{
		StartText.color = Color.gray;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		StartText.color = Color.white;
	}
}
