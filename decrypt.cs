// https://dotnetfiddle.net/b5Da7A
using System;
using System.IO;
using System.Security.Cryptography;

for (;;)
{
    var input = Console.ReadLine() ?? throw new ArgumentNullException();
        //"IegY21/091yYehMIQUAncP9X1ZysdCXyeguJZXrk4dtBKa/lCTaC2RzTS5ZmyV7qghKo/BE3mSVFM2EMKXx+QFYSFGFdJIqci0ClgJlMT/rCuT4oKcm9LcwVeyXji8fJNHUrudK/eWUDwqPGDLYzkWbGFebxmW/sMpi5nHHQB9h/Kyn4LM74FDv4CcyG/fi/JVWQ0Iad3qmR0nr6Rh1uUwyhzzOQ3V3Uww8TjbHF/CEzK5Jg4ucC5t2NnVxuVf4jF3lyX7ZC5yArZuOob1qwTMHavdo30jtoxeWFiLwnHrFhII4laUuKj750tAq0lUQcFTKEfqfEIcbopZPnbXXBlZfga211H+uQ/IL+DRXt2Webr06DK90NvnsroPoyAWE+57v0hjcWQaoIDAPaUOvTWDQ29tuxK9G9WeW+xNiUEAaKrQI+HL0OyPwK7qwm37evIuU9CMyvCFZ11xILE/h1LwZs9RRPrn2VvmAhwwZdAvaMeUy80tF3set8nxKNjY2SCfe0tI2GUO9c12Ky1BGA+54Qphybd8hyTx7vOyvan1zCD0/cG9YS1AhqSBA/IXISPYsmTozWc60cbVAAJz8HCAlg1ELALd8K4NpDemnmKBin4GtAITTQR47f42xV7JCGe0/iIsJiGm53OzknttgT4ZD/7RmsNIwY1a4JExNDfuFeOmPT2hwoMqJmCMUcUKFyK2D+FEcvU/d0bAKm9NgjQLEjKZ3NQr8KX553GH3dbRzQUaz4tCCtvhZEglEuHsxmvMCkC8AewwwfQ6CO936k9dLLPeVM+AL9pRLWzkW6q6Z0i0FBufwqOhs9oicjFQPcn5/C9V4HgT3XR2Sa98E3wBT9ESOAKuj1Cu0vvG/rslzwdv51YHyQxeavlTsPO1LPvbSMfWnqpLXiUSAndFNaIgX/fYYxOZI+pB3Fq6GBH1za9D5yXN5e/JE1s1n01+qUW+bhw6tJcpGFHpPescQ0GhaTrIcoloZVqKAxerEd+QVsOhjclB8URn41T85Ilmmqd8qku/GB/3iCanKWIwK7iB0kOgQGDedVLOzMqjegiNFcPtjbGY8EUuh8Hcjz9sMmkNuflXJtasJU5JTYgYnK19i/2o/OOdvaj7UNG5byNu/IFRbUlXxtlyhuERwcy0L1wSEr/UgLNIE/kBgea9Ni2CIJcT7sRtwbPvSGkE7bw/ziNFj4ltsydsSg7wwUylqDE5Gr/IPKxZvScRUkjpQvT6q/xBmc/OapoL9itCf5BTw9kgvIHlGnOOYXTpWErwv4b7+IYcjoBIsQFsh1bMkxRRFMhWtXwZHm5QQCihMo7AF0d4BWUsruTRjCe2fQbCMCOfH2+DFE+gvVG4jnY/xxxx5qXb7FGWUuTX4sgiaGpPAOUc+cUsWgBtgBg3gIWQfPUhAk0d4u8SYdCuePDYVvB+SNPS9erwKPiBkCI8XbVlKDsWWvAHjw1/sFndlAmCpqf3f51RDjppzW/V3X6Wtfaw8zWrrOEyx5aUsxdFQeuXeZNdnyuxhVayUNCCKeHdZZ/5mLBNRDS9/mJxtHink9yGhf0TYPXgh97K4qGUTDPXfFui6gx1trsP/WlYNmzoM7vUKVALeGayooNSVmgidYIGPgiu70BQ/MwP4adSvirzUtgDPK5Y6cJ69MRLAYHNaMvSDPu7Tk9rR5xRwVADw/KwDBmXOFIgCYB5sMmbIy1lBFuv2TxZ9ufSIyrNG0xm4C";
    var aes = Aes.Create();
    aes.Key = new byte[] {57,114,107,120,67,80,108,106,83,77,49,71,86,81,104,87,119,49,114,49,114,75,79,72,71,99,99,98,50,105,74,53};
    aes.IV = new byte[16];
	
    try
    {
        byte[] buffer = Convert.FromBase64String(input);
        MemoryStream memoryStream = new MemoryStream(buffer);
        CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read, false);
        StreamReader streamReader = new StreamReader(cryptoStream);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(streamReader.ReadToEnd());
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ResetColor();
    }
}
