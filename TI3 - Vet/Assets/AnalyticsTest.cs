using System.Collections.Generic;
using UnityEngine;
using System.Net.Mail;
using System.Net;
using System.IO;

public class AnalyticsTest : MonoBehaviour
{
    public List<AnalyticsData> data;
    public static AnalyticsTest Instance { get; private set; }
    void Awake()
    {
        if(Instance == null)
            Instance = this;
        data = new List<AnalyticsData>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S)) 
        //{
        //    Save();
        //}
    }

    public void AddAnalytics(string sender, string track, string value)
    {
        AnalyticsData d = new AnalyticsData(Time.time, sender, track, value);
        Debug.Log("Send: " + d.sender + ". Track: " + d.track + ". Value: " + d.value);
        data.Add(d);
    }

    public void Save()
    {
        AnalyticsFile f = new AnalyticsFile();
        f.data = data.ToArray();
        string json = JsonUtility.ToJson(f, true);
        SaveFile(json);
        //SendEmail(json);
    }

    void SaveFile(string text) 
    {
        string path = Application.dataPath + "/Analytics.txt";
        Debug.Log("Arquivo salvo em: " +  path);
        File.WriteAllText(path, text);
    }
    
    void SendEmail(string text)
    {
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential("tuliodiasa@gmail.com", "secd cpzp pnvp askz"),
            EnableSsl = true
        };
        client.Send("AnalyticsPDJ3@gmail.com", "tuliodiasa@hotmail.com", "Dados do Analytics", text);
        Debug.Log("Email enviado");
    }
}
