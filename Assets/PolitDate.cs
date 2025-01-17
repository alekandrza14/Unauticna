using System.IO;
using UnityEngine;
public enum politicfreedom
{
    NonPositionalian = 0 ,avtoritatian = 1 ,lidertatian = 2 ,democratian = 3 ,centrarian = 4
}

public class PolitDate
{
    static politicfreedom memory;
    public static politicfreedom IsVersion()
    {
        politicfreedom now = politicfreedom.lidertatian;
        if (memory == politicfreedom.NonPositionalian)
        {
            if (File.Exists("PoliticSettings.ini"))
            {
                now = (politicfreedom)int.Parse(File.ReadAllLines("PoliticSettings.ini")[1]);
                memory = now;
            }
        }
        else
        {
            now = memory;
        }
        return now;
    }
    public static bool IsGood(politicfreedom politic)
    {
        bool now = false;
        if (IsVersion() == politicfreedom.centrarian)
        {
            if (politic == politicfreedom.centrarian)
            {
                now = true;
            }
            else
            {
                now = false;
            }
        }
        if (IsVersion() == politicfreedom.lidertatian)
        {
            if (politic == politicfreedom.lidertatian)
            {
                now = true;
            }
            else if (politic == politicfreedom.democratian)
            {
                now = true;
            }
            else if (politic == politicfreedom.centrarian)
            {
                now = true;
            }
            else
            {
                now = false;
            }
        }
        if (IsVersion() == politicfreedom.avtoritatian)
        {
            if (politic == politicfreedom.avtoritatian)
            {
                now = true;
            }
            else if (politic == politicfreedom.democratian)
            {
                now = true;
            }
            else if (politic == politicfreedom.centrarian)
            {
                now = true;
            }
            else
            {
                now = false;
            }
        }
        if (IsVersion() == politicfreedom.democratian)
        {

            now = true;

        }
        if (IsVersion() == politicfreedom.NonPositionalian)
        {
            if (politic == politicfreedom.NonPositionalian)
            {
                now = true;
            }
        }
        return now;
    }
}
