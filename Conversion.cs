﻿using System.Text.Json;

    public class InputData
    {
        public string? Message { get; set; }
        public string? Name { get; set; }
    }

    public class OutputData
    {
        public string? NewMessage { get; set; }
        public string? NewName { get; set; }
    }

    public class Conversion
    {
        public void ToJson(string inputPath, string outputPath)
        {
            string? json; //Input String
            string outJson = ""; //Output String

            //Reading Input Json and converting it to string
            using (StreamReader r = new StreamReader(inputPath))
            {
                json = r.ReadToEnd();
                Console.WriteLine(json);
            }
            InputData? inputData = JsonSerializer.Deserialize<InputData>(json);

            //Processing the input Json
            if (inputData != null && inputData.Message != null && inputData.Name != null)
            {
                OutputData? outputData = new()
                {
                    NewMessage = inputData.Message.ToLower(),
                    NewName = inputData.Name.ToUpper()
                };

                //Conversion of .NET object to Json String
                outJson = JsonSerializer.Serialize(outputData);
                Console.WriteLine(outJson);
            }

            //Output File Creation and Updation
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
            File.WriteAllText(outputPath, outJson);
        }
    }
