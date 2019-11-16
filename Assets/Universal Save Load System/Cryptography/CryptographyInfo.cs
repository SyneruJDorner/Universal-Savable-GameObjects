using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public static class CryptographyInfo
{
    //public string filePath = @"C:\Users\username\Desktop\wordFileExample.doc";

    public static void Encrypt(string filePath, string fileFormat)
    {
        string password = "ThePasswordToDecryptAndEncryptTheFile";
        GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);
        CryptographySystem.FileEncrypt(filePath, fileFormat, password);
        CryptographySystem.ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
        File.Delete(filePath);
        gch.Free();

        Debug.Log("The given password is surely nothing: " + password);
    }

    public static void Decrypt(string filePath, string fileFormat)
    {
        string password = "ThePasswordToDecryptAndEncryptTheFile";
        GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);
        CryptographySystem.FileDecrypt(filePath + "." + fileFormat, filePath, password);
        CryptographySystem.ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
        File.Delete(filePath + @".aes");
        gch.Free();

        // You can verify it by displaying its value later on the console (the password won't appear)
        Debug.Log("The given password is surely nothing: " + password);
    }
}
