using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
public class SelectionBox : MonoBehaviour
{
    public RectTransform box;

    private Vector2 startPos;
	void Start()
	{
		foreach (CustomObject unit in FindObjectsOfType<CustomObject>())
		{
			gameObject.AddComponent<SelectObjectTag>();
		}
	} 
	public List<SelectObjectTag> selected = new List<SelectObjectTag>();

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.E)) // ПКМ
        {
			FindObjectOfType<UnitManager>().units = new List<SelectObjectTag>(selected);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
				if(selected.Count>10&& selected.Count<25){
                Vector3 center = hit.point;

				float spacing = 2f;
				
				for (int i = 0; i < selected.Count; i++)
				{
					Vector3 offset = new Vector3(
						(i % 5) * spacing,
						0,
						(i / 5) * spacing);
				
					selected[i].MoveTo(center + offset);
				} }else if(selected.Count>25&& selected.Count<100){
                Vector3 center = hit.point;

				float spacing = 2f;
				
				for (int i = 0; i < selected.Count; i++)
				{
					Vector3 offset = new Vector3(
						(i % 10) * spacing,
						0,
						(i / 10) * spacing);
				
					selected[i].MoveTo(center + offset);
				} }else if(selected.Count>100&& selected.Count<10000){
                Vector3 center = hit.point;

				float spacing = 2f;
				
				for (int i = 0; i < selected.Count; i++)
				{
					Vector3 offset = new Vector3(
						(i % 10) * spacing,
						(i / 100) * spacing,
						((i / 10)-((i / 100))*10) * spacing);
				
					selected[i].MoveTo(center + offset);
				} }else{ Vector3 center = hit.point;

				float spacing = 2f;
				
				for (int i = 0; i < selected.Count; i++)
				{
					Vector3 offset = new Vector3(
						(i % 5) * spacing,
						0,
						(i / 2) * spacing);
				
					selected[i].MoveTo(center + offset);
				}}
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            box.gameObject.SetActive(true);
        }

        if (Input.GetMouseButton(0))
        {
            DrawBox(startPos, Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            box.gameObject.SetActive(false);

            Rect rect = new Rect(
			Vector2.Min(startPos, Input.mousePosition),
			Vector2.Max(startPos, Input.mousePosition) - Vector2.Min(startPos, Input.mousePosition)
			);
			
			foreach (SelectObjectTag unit in FindObjectsOfType<SelectObjectTag>())
			{
				Vector3 screen = Camera.main.WorldToScreenPoint(unit.transform.position);
			
				if (rect.Contains(screen))
				{
					unit.Select();
					if(!selected.Contains(unit))selected.Add(unit);
				}
				else
				{
					if(!Input.GetKey(KeyCode.LeftShift)&&!Input.GetKey(KeyCode.RightShift))
					{
						unit.Deselect();
						if(selected.Contains(unit))selected.Remove(unit);
					}
				}
			}
			
        }
    }

    void DrawBox(Vector2 start, Vector2 end)
    {
        Vector2 min = Vector2.Min(start, end);
        Vector2 max = Vector2.Max(start, end);

        box.position = min;
        box.sizeDelta = max - min;
    }
}