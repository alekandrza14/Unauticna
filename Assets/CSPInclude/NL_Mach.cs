using UnityEngine;//CUT
//Path file"Assets\CSPInclude\"[Name].cs
public class NL_Mach : MonoBehaviour//CUT
{//CUT
	
    static PY.ector3 Vector3(string x,string y,string z){return new PY.ector3(x,y,z);}
	object Vector3zero = new UnityEngine.Vector3(0,0,0);
	object Vector3up = new UnityEngine.Vector3(0,1,0);
	object Vector3down = new UnityEngine.Vector3(0,-1,0);
	object Vector3right = new UnityEngine.Vector3(1,0,0);
	object Vector3left = new UnityEngine.Vector3(-1,0,0);
	object Vector3forward = new UnityEngine.Vector3(0,0,1);
	object Vector3beck = new UnityEngine.Vector3(0,0,-1);
	
}//CUT
namespace PY {//CUT
	public class ector3{public string x,y,z; public ector3(string x,string y,string z){this.x = x;this.y = y;this.z = z;}}//CUT
}//CUT


public class St{public static int ri(string a){return 0;}public static string ri2(string a){return a;}}//CUT