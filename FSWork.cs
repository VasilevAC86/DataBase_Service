using System;

using System.IO;

namespace Service
{
    internal class FSWork // Чтобы база не задвайвалась
    {
        static public bool IsFileExist(string path)
        {
            bool result = false;
            if (File.Exists(path))
            {
                result = true;
            }
            return result;
        }
    }
}
