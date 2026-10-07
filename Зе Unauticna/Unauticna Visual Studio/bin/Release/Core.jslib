*_Begin_*начать с релаизации физики*_Begin_**_BeginDialog_*Привет это создание скриптов через новелу! как мы начнём?*_BeginDialog_*
*_List1_*

*_начать с релаизации физики_*

function Start()
{
	AddSharpComponent(This,"UnityEngine.Rigidbody");
	//Module"List2".Core.jslib
}

function Update()
{
//Module"List3".Core.jslib
}
*_начать с релаизации физики_*

*_List1_*

*_List1.end_*это персонаж,это предмет,это машина*_List1.end_**_List1Dialog_*что мы делаем?*_List1Dialog_*

*_List2_*

*_это персонаж_*
	var obj = new ThisClass("Camera");
	AddSharpComponent(obj,"UnityEngine.Camera");
	obj.transform.SetParent(Origin);
	obj.transform.position = new Vector3(
	Origin.position.x+0,
	Origin.position.y+2.5,
	Origin.position.z-4);//-это работает
	obj.transform.rotation = new Quaternion(
	0.2392961,
	0,
	0,
	0.9709466);//-это работает
	obj.tag = "MainCamera";
	PlayerActive(false);
*_это персонаж_*



*_это предмет_*
//item
*_это предмет_*


*_это машина_*
//mobile
*_это машина_*

*_List2_*

*_List2.end_*игрок управляет,само двигаеться*_List2.end_**_List2Dialog_*в периуде своего существования это?*_List2Dialog_*

*_List3_*

*_игрок управляет_*

    timer = timer + 1 * Time.DeltaTime;
 //Debug.Log("Hello"+timer);
    if(timer < 60*3)
    {   
		var qua = new Quaternion(0,0,0,0);
		qua = Origin.transform.rotation;
		Origin.transform.rotation = new Quaternion(
		0,
		qua.y,
		0,
		qua.w);
		//TransformAPI.Translate(Origin, Vector3.forward * 5);-не работает хз почему
		//Debug.Log(Vector3.forward);-ошибка в юнити нет Vector3.forward это занчит и в Jint его не будет
		//Debug.Log(Origin.forward);-не работает хз почему возможно потому что Jint не может передать обекты в C#
		//Debug.Log(Origin.forward.x);-это работает
		//Origin.Translate(Origin.forward * 5);-это тоже не работает
		//Origin.position = new Vector3(0, 2, 0);//-это рабоает
		//Origin.position = Origin.forward * 5.0;-это не работает тут он ругаеться на перравельный тип данных
		//Origin.position = Origin.forward * 5.0f;-это не работает тут он ругаеться на хз
		//Origin.position = new Vector3(Origin.forward.x* 5, Origin.forward.y* 5, Origin.forward.z* 5);//-это рабоает но обект стоит на месте
		//Origin.position = 
		//new Vector3(
		//Origin.position.x+Origin.forward.x * Time.DeltaTime * 5,
		//Origin.position.y+Origin.forward.y * Time.DeltaTime * 5,
		//Origin.position.z+Origin.forward.z * Time.DeltaTime * 5);-это работает
		if(Input.GetKey("w"))
		{
			Origin.Translate(new Vector3(
			Vector3.forward.x * Time.DeltaTime * 5,
			Vector3.forward.y * Time.DeltaTime * 5,
			Vector3.forward.z * Time.DeltaTime * 5));//-это рабоает
		}
		if(Input.GetKey("a"))
		{
			Origin.Rotate(new Vector3(
			0 * Time.DeltaTime * 5,
			-15 * Time.DeltaTime * 5,
			0 * Time.DeltaTime * 5));//-это рабоает
		}
		if(Input.GetKey("d"))
		{
			Origin.Rotate(new Vector3(
			0 * Time.DeltaTime * 5,
			15 * Time.DeltaTime * 5,
			0 * Time.DeltaTime * 5));//-это рабоает
		}
    }else
	{
	     PlayerActive(true);
		 This.SetActive(false);
	}
*_игрок управляет_*



*_само двигаеться_*
//self Move
*_само двигаеться_*

*_List3_**_List3.end_**_List3.end_**_List3Dialog_**_List3Dialog_*
*_List4_**_List4_**_List4.end_**_List4.end_**_List4Dialog_**_List4Dialog_*