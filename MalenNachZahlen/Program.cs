using MalenNachZahlen;
using System.IO;
using System.Threading.Channels;

KoordinateSystem system = new KoordinateSystem();
List<Point> result = system.ReadCSV("/Users/max/RiderProjects/MalenNachZahlen/MalenNachZahlen/dateien/sw.csv");
system.SetField();
system.printField();
