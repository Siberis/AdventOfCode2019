using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Utils
{
    public class ReadUtils
    {
        public static async Task<string[]> ReadAllLines(string path)
        {
            return await File.ReadAllLinesAsync(path, Encoding.UTF8).ConfigureAwait(false);
        }
        public static async Task<string[]> ReadWithSeparator(string path, char separator)
        {
            var list = await File.ReadAllLinesAsync(path, Encoding.UTF8).ConfigureAwait(false);
            return list.SelectMany(e => e.Split(separator)).ToArray();
        }
    }
}
