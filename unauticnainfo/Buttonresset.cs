using Godot;
using System;
public class GetUniverse
{
	static public string Universe()
	{
		string universe = "MU Unuaticna";
		if (System.IO.File.Exists("Unauticna.exe"))
		{
			universe = "U Unauticna";
		}
		if (System.IO.File.Exists("Deltafate.exe"))
		{
			universe = "U Deltafate";
		}
		if (System.IO.File.Exists("Enteria.exe"))
		{
			universe = "U Enteria";
		}
		return universe;
	}
}

public class Buttonresset : Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	private void _on_Button2_button_down()
	{
		if (GetUniverse.Universe() == "U Unauticna")
		{

			if (System.IO.Directory.Exists("unsave"))
			{
				System.IO.Directory.Delete("unsave", true);
			}
			if (System.IO.Directory.Exists("munsave"))
			{
				System.IO.Directory.Delete("munsave", true);
			}
			if (System.IO.Directory.Exists("unsavet"))
			{
				System.IO.Directory.Delete("unsavet", true);
			}
			if (System.IO.Directory.Exists("debug"))
			{
				System.IO.Directory.Delete("debug", true);
			}
			if (System.IO.Directory.Exists("world"))
			{
				System.IO.Directory.Delete("world", true);

			}

		}
		if (GetUniverse.Universe() == "U Deltafate")
		{


			if (System.IO.Directory.Exists("debug"))
			{
				System.IO.Directory.Delete("debug", true);
			}
			if (System.IO.Directory.Exists("DELTAFATE"))
			{
				System.IO.Directory.Delete("DELTAFATE", true);
			}
			if (System.IO.Directory.Exists("sins"))
			{
				System.IO.Directory.Delete("sins", true);
			}


		}
	}
}


