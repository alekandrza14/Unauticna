//Using﴾NL_Git﴿
//Using﴾NL_IO﴿
//Using﴾NL_Mach﴿
//RpeBeginUsing
using UnityEngine;
using UnityEngine.UI;
//CSPBegin
//.
public class textDownload : CSPBehaviour
{
	//Include
	//PUBLIC ONLYCSP
	RawImage pic;
	float[,,] _3DMasive;
	//PUBLIC ONLYCSP
	string Get3DMasive;
	//cspvoid Start()
	//csp{
		//CSP.Climp("textDownload",this);
	//csp}
	//cspvoid Update()
	//csp{
	//csp	
	//csp}
    public void Button()
    {
		object image = null;
		//error scip
		//GitConnect﴾alekandrza14.YourAcount.file.png,C:/data/textDownloaded﴿.download
		//IO﴾Load=C:/data/textDownloaded﴿>>image
		
		pic.texture = (Texture2D)image;
		Vector3 i = Vector3.zero;
		var dat = new Vector3(St.ri("0"),St.ri("0"),St.ri("0"));
		_3DMasive = new float[2,2,2];
		//For3D﴾i = 0&i.x<2,i.y<2,i.z<2&i.x++,i.y++,i.z++﴿
			_3DMasive[(int)i.x,(int)i.y,(int)i.z] = 1;
			Get3DMasive += ""+_3DMasive[(int)i.x,(int)i.y,(int)i.z]+" X:"+i.x+" Y:"+i.y+" Z:"+i.z+"\n";
		//For3DEnd
		
	}
	public void Unsing()
    {
		Vector4 i2 = Vector4.zero;
		Vector4 i3 = Vector4.zero;
		//For8D﴾[i2,i3] = 0&i2.x<2,i2.y<2,i2.z<2,i2.w<2,i3.x<2,i3.y<2,i3.z<2,i3.w<2&i2.x++,i2.y++,i2.z++,i2.w++,i3.x++,i3.y++,i3.z++,i3.w++﴿
		//For8DEnd
		Vector4 i4 = Vector4.zero;
		Vector4 i5 = Vector4.zero;
		//For16D﴾[i2,i3,i4,i5] = 0&i2.x<2,i2.y<2,i2.z<2,i2.w<2,i3.x<2,i3.y<2,i3.z<2,i3.w<2,i4.x<2,i4.y<2,i4.z<2,i4.w<2,i5.x<2,i5.y<2,i5.z<2,i5.w<2&i2.x++,i2.y++,i2.z++,i2.w++,i3.x++,i3.y++,i3.z++,i3.w++,i4.x++,i4.y++,i4.z++,i4.w++,i5.x++,i5.y++,i5.z++,i5.w++﴿
		//For16DEnd
	}
	public static string script = "Assets\\Adons\\100 assets\\26\\textDownload";
	//csp
	
}
//CSPEnd