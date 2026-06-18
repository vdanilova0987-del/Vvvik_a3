using System.IO.Pipes;
using System.Text;

using var pipe = new NamedPipeServerStream("mypipe", PipeDirection.InOut);
pipe.WaitForConnection();

using var reader = new StreamReader(pipe, Encoding.UTF8);
using var writer = new StreamWriter(pipe, Encoding.UTF8) { AutoFlush = true };

string text = reader.ReadLine();
File.AppendAllText("log.txt", $"{DateTime.Now}: {text}\n");
writer.WriteLine(text.ToUpper());