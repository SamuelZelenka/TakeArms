using System.IO;
using UnityEngine;

namespace TakeArms.Utility
{
    public static class SaveSystem
    {
        public static readonly string ENCRYPTION_KEY = "Tot@llyNöt1Two3Foµr";

        public static string GetDirectoryPath(string directory)
        {
#if UNITY_EDITOR
            return Application.dataPath + $"/{directory}/";      
#else      
            return Application.persistentDataPath + $"/{directory}/"; 
#endif
            
        }

        public static void SaveData(string fileName, string directory, string jsonString, string fileType)
        {
            string path = GetDirectoryPath(directory);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string encryptedData = StringEncryption.Encrypt(jsonString, ENCRYPTION_KEY);

            File.WriteAllText(path + fileName + fileType, encryptedData);
            Debug.Log($"Saved {fileName}");
        }

        public static T LoadData<T>(string fileName, string directory, string fileType) where T : ISavable
        {
            string data = GetDataString(fileName, directory, fileType);
            Debug.Log($"Loaded {fileName}");
            return JsonUtility.FromJson<T>(data);
        }

        public static string GetDataString(string saveName, string directory, string fileType)
        {
            saveName = GetDirectoryPath(directory) + saveName + fileType;
            if (File.Exists(saveName))
            {
                string rawData = File.ReadAllText(saveName);
                string decryptedData = StringEncryption.Decrypt(rawData, ENCRYPTION_KEY);
                return decryptedData;
            }
            return null;
        }
        
        public static bool DeleteFile(string fileName, string directory, string fileType)
        {
            string path = GetDirectoryPath(directory) + fileName + fileType;
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        public static string[] GetFilesOfType(string fileType, string directory)
        {
            string mapDirectoryPath = SaveSystem.GetDirectoryPath(directory);
            return Directory.GetFiles(mapDirectoryPath, $"*{fileType}");
        }
    }
}
