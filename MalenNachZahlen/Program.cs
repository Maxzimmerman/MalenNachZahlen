using MalenNachZahlen;
using System.IO;
using System.Threading.Channels;

string path = "H:\\c#repo\\MalenNachZahlen\\MalenNachZahlen\\dateien\\butterfly.csv";
string filedata = "";
string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o" };
using (StreamReader reader = new StreamReader(path))
{
    if(!reader.EndOfStream)
    {
        filedata = reader.ReadToEnd();
    }
}

for(int letter = 0; letter < alphabet.Length; letter++)
{
    for (int i = 0; i < filedata.Length; i++)
    {
        if (alphabet[i] == filedata[i].ToString().ToLower())
        {
            Console.WriteLine("Match");
        }
        Console.WriteLine(filedata[i]);
    }
}

