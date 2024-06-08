using UnityEngine;
using System.Collections;


public class FileSelectorExample : MonoBehaviour {
	
	private GUIStyle style;
	[HideInInspector]
	public string path = "";
	[HideInInspector]
	public bool usewindowOpen;


	private bool windowOpen; 
	void Start()
	{
		style = new GUIStyle();
		style.fontSize = 40;
		
		style.normal.textColor = Color.white;
	}
	
	void OnGUI(){
		//Instructions
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//if we don't have an open window yet, and the spacebar is down...
		if(usewindowOpen&&!windowOpen)
		{
			FileSelector.GetFile(GotFile, ".json"); //LoadTerraform a new FileSelector window
			windowOpen = true;
		}
	}
				
	//This is called when the FileSelector window closes for any reason.
	//'Status' is an enumeration that tells us why the window closed and if 'path' is valid.
	public void GotFile(FileSelector.Status status, string path){
		Debug.Log("File Status : "+status+", Path : "+path);
		this.path = path;
		this.usewindowOpen = false; 
		this.windowOpen = false;
	}
}
