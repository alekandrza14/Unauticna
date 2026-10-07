using UnityEngine;//CUT
//Path file"Assets\CSPInclude\"[Name].cs
using System.Net;//PreBegin
using System.IO;//PreBegin
public class NL_Git : MonoBehaviour//CUT
{//CUT
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
	
}//CUT
