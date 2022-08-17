using Godot;
using System;

public class Buttondebug : Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
	private void _on_Button_button_down()
	{
		getDebug();

	}
	void getDebug ()
	{
		if (System.IO.Directory.Exists("debug"))
		{
			System.IO.Directory.Delete("debug",true);
		}
		else
		{
			System.IO.Directory.CreateDirectory("debug");
		}
	}

}



