var timer = 0;

function Start()
{
    Debug.Log("Hello");
	var obj = new ThisClass("Camera");
	AddSharpComponent(obj,"UnityEngine.Camera");
	//AddSharpComponent(This,"UnityEngine.Rigidbody");
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
}

function Update()
{
    timer = timer + 1 * Time.DeltaTime;
 //Debug.Log("Hello"+timer);
    if(timer < 60*3)
    {   
		//CppRealtime/Main.exe
    }
	else
	{
	     PlayerActive(true);
		 This.SetActive(false);
	}
  // Origin.position = new Vector3(0, 2, 0);
}
//uns+using+AsoluteUnityAPI