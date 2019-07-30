using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
public class Globe
{
  //在这里记录当前切换场景的名称 
  public static string loadName;
  public static int loadIndex =11;

  public static float AutoWaitingTime = 30F;
  public static double gameAllTime = 0;
  public static double[] ScenesFixTime = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,0,0,0,0};
  public static float[]  SenesMaxSpeed = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,0,0,0,0};

  public static float g_Score = 0;
  public static float g_High = 0;

  public static string _txtPath = "/my_data/_Info.xml";
  public static string current_data_path()
  {
    string text1 = Application.dataPath;
    return text1.Substring(0, text1.LastIndexOf('/'));
  }

  	public static string getXmlStr(string nodeName)
	{

    StreamWriter writer;
    FileInfo t = new FileInfo(Globe.current_data_path() + _txtPath);
    if (!t.Exists)
    {
      writer = t.CreateText();
      writer.Close();
    }
    StreamReader r = File.OpenText(Globe.current_data_path() + _txtPath);
    string _s = r.ReadToEnd();

    XmlDocument xmlDoc = new XmlDocument();
	
	try {
	    xmlDoc.Load(new StringReader(_s));

	    string xmlPathPattern = "//Config";
	    XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
			
			foreach (XmlNode nodels in myNodeList)
			{
				if (nodels.Name == nodeName)
				{
					return nodels.InnerXml;
				}
				foreach (XmlNode node in nodels)
				{
					if (node.Name == nodeName)
					{
						return node.InnerXml;
					}
				}
			}
		} catch(System.Exception E) {
			Debug.Log(E.Message);
		}

		return "";
	}

  public static bool _gameEnd = false;
  public static void _GameDatarest()
  {

    loadIndex = 10;
    gameAllTime = 0;
    _gameEnd = false;
    for (int i = 0; i < ScenesFixTime.Length; i++)
    {
      ScenesFixTime[i] = 0.0f;
      SenesMaxSpeed[i] = 0.0F;
    }
     // ScenesFixTime.Initialize();
    //SenesMaxSpeed.Initialize();
  }
  public static void _GameRest()
  {
    _GameDatarest();
    Application.LoadLevel(0);
  }
}