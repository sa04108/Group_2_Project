using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialParser : MonoBehaviour
{
    public Tutorial[] parse(string _CSVFileName)
    {
        List<Tutorial> TutorialList = new List<Tutorial>();
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        string[] data = csvData.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });

            Tutorial tutorial = new Tutorial();

            List<string> contextList = new List<string>();
            contextList.Add(row[1]);

            if (++i<data.Length)
            {
                ;
            }

            tutorial.contexts = contextList.ToArray();
            TutorialList.Add(tutorial);
        }
        return TutorialList.ToArray();
    }
}
