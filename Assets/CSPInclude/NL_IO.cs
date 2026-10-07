using UnityEngine;//CUT
using System.IO;//PreBegin
//Path file"Assets\CSPInclude\"[Name].cs
public class NL_IO : MonoBehaviour//CUT
{//CUT
Texture2D LoadTexure(string filename)//Get IO{Load}=LoadTexure
{
    if (!System.IO.File.Exists(filename))
        return null;

    byte[] data =
        System.IO.File.ReadAllBytes(filename);

    Texture2D texture =
        new Texture2D(2, 2);

    if (!texture.LoadImage(data))
    {
        Destroy(texture);
        return null;
    }

    return texture;
}
	////IO﴾Load=C:/data/textDownloaded﴿>>image
	//image = LoadTexure("C:/data/textDownloaded");
}//CUT
