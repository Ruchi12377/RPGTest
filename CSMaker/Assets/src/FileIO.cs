using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    public static class FileIO
    {
        public static async Task Read(string path)
        {
            using var sr = new StreamReader(Path.GetFullPath(path), System.Text.Encoding.UTF8);
            await sr.ReadToEndAsync();
        }

        public static async Task Write(string path, StringBuilder data)
        {
            await Write(path, data.ToString());
        }
    
        public static async Task Write(string path, string data)
        {
            using var sw = new StreamWriter(Path.GetFullPath(path), false, System.Text.Encoding.UTF8);
            await sw.WriteAsync(data);
        }
    }
}
