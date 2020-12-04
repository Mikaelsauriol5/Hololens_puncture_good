using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using UnityEngine;

public class CsvReadWrite
{
    private TMPro.TextMeshPro debugText;

    private List<string[]> rowData = new List<string[]>();
    private string filePath;
    private string fileFormat = ".csv";

    public CsvReadWrite(string fileName)
    {
        filePath = Path.Combine("C:/Data/Users/Mikae/Documents", fileName + fileFormat);

        //debugText = GameObject.Find("debugText").GetComponent<TMPro.TextMeshPro>();
        //debugText.text = filePath;

        if (!File.Exists(filePath))
        {
            // Creating First row of titles manually..
            string[] rowDataTemp = new string[4];
            rowDataTemp[0] = "Angle";
            rowDataTemp[1] = "X";
            rowDataTemp[2] = "Y";
            rowDataTemp[3] = "Z";
            rowData.Add(rowDataTemp);

            Save();
        }
    }

    public void Save() 
    {
        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));

        using (StreamWriter outStream = new StreamWriter(filePath))
        {
            outStream.WriteLine(sb);
            outStream.Close();
        }
    }

    public void Write(float angle, float x, float y, float z)
    {
        string[] rowDataTemp = new string[4];
        rowDataTemp[0] = Math.Round(angle,1).ToString();
        rowDataTemp[1] = Math.Round(x, 2).ToString(); 
        rowDataTemp[2] = Math.Round(y, 2).ToString(); 
        rowDataTemp[3] = Math.Round(z, 2).ToString();
        rowData.Add(rowDataTemp);
  
        Save();
    }

}