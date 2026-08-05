using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class GitHubSearch : MonoBehaviour
{
    public List<string> accounts = new List<string>();
	public int page = 1;
    public GameObject Acount;
    public Transform Folder;
    public List<GameObject> Buttons = new List<GameObject>();
    void Start()
    {
        StartCoroutine(Start1());
    }
    public void Next()
    {
        page++;
        StartCoroutine(Start1());
    }
    public void Back()
    {
        page--;
        StartCoroutine(Start1());
    }
    IEnumerator Start1()
    {
        string repoName = "YourAcount";

        using (UnityWebRequest www = UnityWebRequest.Get(
            "https://api.github.com/search/repositories?q=" + repoName + "+in:name&per_page=100&page="+page))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
                yield break;
            }

            string json = www.downloadHandler.text;

            accounts.Clear();

            MatchCollection matches = Regex.Matches(
                json,
                "\"full_name\"\\s*:\\s*\"([^\"]+)\"");

            foreach (Match m in matches)
            {
                string fullName = m.Groups[1].Value;
                accounts.Add(fullName);
                GameObject obj = Instantiate(Acount, Folder);
                obj.GetComponent<ButtonFolder>().user = fullName;
                Buttons.Add(obj);
            }

            foreach (string account in accounts)
            {
                Debug.Log(account);
            }
        }
    }
}