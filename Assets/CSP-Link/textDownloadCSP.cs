


using System.Net;
using System.IO;
//RpeBeginUsing
using UnityEngine;
using UnityEngine.UI;
namespace var157086
{
public class textDownloadCSP : CSPBehaviour
{
	//Include
//Path file"Assets\CSPInclude\"[Name].cs
    void git(string link,string file,string command)//Use GitConnect
	{
		if(command == "DOWNLOAD")
		{
			Download(ToURL(link),file);
		}
	}
	////GitConnect﴾alekandrza14.YourAcount.file.png,C:/data/textDownloaded﴿.download
	//1 это GitConnect﴾alekandrza14.YourAcount.file, создаёт ссылку длягит хаба он же string link для фукции ToURL() тут видно имя автора и репозитроия пример https://alekandrza14.github.io/YourAcount/file.png
	//2 это .download для понимания что мы делаем проверяем файл или ссыллку или качаем файл поссылке что мы с генерировали он же string command для if(){} дерева условий
	//3﴾C:/data/textDownloaded﴿ качает файл по сгенерированой ссылке он хе string file для фукции Download()
	//4 это GitConnect он понимает что мы заменяем это GitConnect﴾alekandrza14.YourAcount.file.png,C:/data/textDownloaded﴿.download на git("alekandrza14.YourAcount.file.png","C:/data/textDownloaded","DOWNLOAD"); что использовать будем имено эту ссылку говорит //Use GitConnect
	//работает репласинг по такому алогоритму [NAME]﴾string2,string2,...﴿.FLAG в nameT(string2,string2,...,FLAG);
	// void nameT(string2,string2,...,FLAG)//Use [Name]
	//{...
	string ToURL(string link)
	{
		string[] split = link.Split('.');
		string linkDone = "https://"+split[0]+".github.io/"+split[1]+"/"+link.Replace(split[0]+"."+split[1]+".","");
		return linkDone;
	}
    string Download(string link, string file)
{
    try
    {
        string directory = Path.GetDirectoryName(file);

        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }

        using (WebClient client = new WebClient())
        {
            client.DownloadFile(link, file);
        }

        Debug.Log(
            "GitConnect DOWNLOAD: " +
            link +
            " -> " +
            file
        );

        return file;
    }
    catch (System.Exception e)
    {
        Debug.LogError(
            "GitConnect DOWNLOAD ERROR: " +
            e.Message
        );

        return null;
    }
}
	

//Path file"Assets\CSPInclude\"[Name].cs
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

//Path file"Assets\CSPInclude\"[Name].cs
	
    static PY.ector3 Vector3(string x,string y,string z){return new PY.ector3(x,y,z);}
	object Vector3zero = new UnityEngine.Vector3(0,0,0);
	object Vector3up = new UnityEngine.Vector3(0,1,0);
	object Vector3down = new UnityEngine.Vector3(0,-1,0);
	object Vector3right = new UnityEngine.Vector3(1,0,0);
	object Vector3left = new UnityEngine.Vector3(-1,0,0);
	object Vector3forward = new UnityEngine.Vector3(0,0,1);
	object Vector3beck = new UnityEngine.Vector3(0,0,-1);
	


	public 	RawImage pic;
	float[,,] _3DMasive;
	public 	string Get3DMasive;
	void Start()
	{
		//CSP.Climp("textDownload",this);
	}
	void Update()
	{
		
	}
    public void Button()
    {
		object image = null;
		//error scip
		git("alekandrza14.YourAcount.file.png","C:/data/textDownloaded","DOWNLOAD");
		image = LoadTexure("C:/data/textDownloaded");
		pic.texture = (Texture2D)image;
		UnityEngine.Vector3 i = (UnityEngine.Vector3)Vector3zero;
		var dat = textDownloadCSP.Vector3(St.ri2("0"),St.ri2("0"),St.ri2("0"));
		_3DMasive = new float[2,2,2];
		for (i.x = 0; i.x<2; i.x++)
		{
			for (i.y = 0; i.y<2; i.y++)
			{
				for (i.z = 0; i.z<2; i.z++)
				{
			_3DMasive[(int)i.x,(int)i.y,(int)i.z] = 1;
			Get3DMasive += ""+_3DMasive[(int)i.x,(int)i.y,(int)i.z]+" X:"+i.x+" Y:"+i.y+" Z:"+i.z+"\n";
				}
			}
		}
		
	}
	public void Unsing()
    {
		Vector4 i2 = Vector4.zero;
		Vector4 i3 = Vector4.zero;
		for (i2.x = 0; i2.x<2; i2.x++)
		{
			for (i2.y = 0; i2.y<2; i2.y++)
			{
				for (i2.z = 0; i2.z<2; i2.z++)
				{
					for (i2.w = 0; i2.w<2; i2.w++)
					{
						for (i3.x = 0; i3.x<2; i3.x++)
						{
							for (i3.y = 0; i3.y<2; i3.y++)
							{
								for (i3.z = 0; i3.z<2; i3.z++)
								{
									for (i3.w = 0; i3.w<2; i3.w++)
									{
									}
								}
							}
						}
					}
				}
			}
		}
		Vector4 i4 = Vector4.zero;
		Vector4 i5 = Vector4.zero;
		for (i2.x = 0; i2.x<2; i2.x++)
		{
			for (i2.y = 0; i2.y<2; i2.y++)
			{
				for (i2.z = 0; i2.z<2; i2.z++)
				{
					for (i2.w = 0; i2.w<2; i2.w++)
					{
						for (i3.x = 0; i3.x<2; i3.x++)
						{
							for (i3.y = 0; i3.y<2; i3.y++)
							{
								for (i3.z = 0; i3.z<2; i3.z++)
								{
									for (i3.w = 0; i3.w<2; i3.w++)
									{
										for (i4.x = 0; i4.x<2; i4.x++)
										{
											for (i4.y = 0; i4.y<2; i4.y++)
											{
												for (i4.z = 0; i4.z<2; i4.z++)
												{
													for (i4.w = 0; i4.w<2; i4.w++)
													{
														for (i5.x = 0; i5.x<2; i5.x++)
														{
															for (i5.y = 0; i5.y<2; i5.y++)
															{
																for (i5.z = 0; i5.z<2; i5.z++)
																{
																	for (i5.w = 0; i5.w<2; i5.w++)
																	{
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
	public static string script = "Assets\\Adons\\100 assets\\26\\textDownload";
	
	
}
}