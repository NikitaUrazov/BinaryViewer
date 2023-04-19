using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer
{
    internal class BinaryViewer
    {
        /// <summary>
        /// Путь к результирующему файлу.
        /// </summary>
        static public string Result { get; } = "result.txt";
        static public string Source { get; set; }
        static public long BeginOffset { get; set; }
        static public long EndOffset { get; set; }
        static public TextBox TargetTextBox { get; set; }

        /// <summary>
        /// Метод, читающий файл и сохраняющий содержимое в бинарном виде в результирующем файле.
        /// </summary>
        /// <param name="file">Файл для прочтения</param>
        static public void Read(string file, long begin_offset, long end_offset, ref TextBox textBox)
        {
            FileStream source = new FileStream(file, FileMode.Open, FileAccess.Read);
            StringBuilder sb = new StringBuilder();

            source.Position = begin_offset;

            try
            {
                const long bytesChunkSize = 16;
                byte[] bytesChunk = new byte[bytesChunkSize];
                textBox.Clear();

                while (source.Position <= end_offset)
                {
                    sb.Clear();

                    //Запись смещения
                    sb.Append($"{source.Position.ToString("X8")}: ");

                    for (int i = 0; i < bytesChunk.Length; i++)
                        bytesChunk[i] = 0;

                    long bytesToRead = bytesChunkSize;
                    long bytesLeft = source.Length - source.Position;
                    if (bytesLeft < bytesToRead)
                        bytesToRead = bytesLeft;

                    source.Read(bytesChunk, 0, (int)bytesToRead);

                    //Запись байт в 16-системе
                    for (int i = 0; i < bytesChunk.Length; i++)
                        sb.Append($"{bytesChunk[i].ToString("X2")} ");

                    sb.Append("| ");

                    //Запись символьного представления байт
                    for (int i = 0; i < bytesChunk.Length; i++)
                    {
                        if (bytesChunk[i] >= 33 && bytesChunk[i] <= 126)
                            sb.Append($"{(char)bytesChunk[i]} ");
                        else
                            sb.Append($". ");
                    }

                    //sw.WriteLine(sb.ToString());
                    textBox.AppendText(sb.ToString() + Environment.NewLine);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                source.Dispose();
            }
        }

        public static void Read()
        {
            FileStream source = new FileStream(Source, FileMode.Open, FileAccess.Read);
            StringBuilder sb = new StringBuilder();

            source.Position = BeginOffset;

            try
            {
                const long bytesChunkSize = 16;
                byte[] bytesChunk = new byte[bytesChunkSize];
                TargetTextBox.Clear();

                while (source.Position <= EndOffset)
                {
                    sb.Clear();

                    //Запись смещения
                    sb.Append($"{source.Position.ToString("X8")}: ");

                    for (int i = 0; i < bytesChunk.Length; i++)
                        bytesChunk[i] = 0;

                    long bytesToRead = bytesChunkSize;
                    long bytesLeft = source.Length - source.Position;
                    if (bytesLeft < bytesToRead)
                        bytesToRead = bytesLeft;

                    source.Read(bytesChunk, 0, (int)bytesToRead);

                    //Запись байт в 16-системе
                    for (int i = 0; i < bytesChunk.Length; i++)
                        sb.Append($"{bytesChunk[i].ToString("X2")} ");

                    sb.Append("| ");

                    //Запись символьного представления байт
                    for (int i = 0; i < bytesChunk.Length; i++)
                    {
                        if (bytesChunk[i] >= 33 && bytesChunk[i] <= 126)
                            sb.Append($"{(char)bytesChunk[i]} ");
                        else
                            sb.Append($". ");
                    }

                    //sw.WriteLine(sb.ToString());
                    TargetTextBox.AppendText(sb.ToString() + Environment.NewLine);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                source.Dispose();
            }
        }

        static public long GetOffsetPosition(long offset, string[] strings)
        {
            if (!CanConvert16To10(strings[0].Split(':')[0], out long currentOffset))
            {
                MessageBox.Show("Error");
                return -1;
            }

            long position = 0;
            bool hasOffset = false;
            string str = "";

            for (int i = 0; i < strings.Length; i++)
            {
                if (currentOffset + 16 > offset)
                {
                    hasOffset = true;
                    str = strings[i];
                    break;
                }

                currentOffset += 16;
                position += strings[i].Length + 1;
            }

            if (!hasOffset)
            {
                MessageBox.Show("Смещение не найдено");
                return -1;
            }

            long j = currentOffset - 1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    j++;
                    if (j == offset)
                    {
                        return position + 1;
                    }
                }
                position++;
            }

            return -1;
        }

        private static bool CanConvert16To10(string str, out long result)
        {
            result = 0;
            int hex_pos = 1;

            int j = 0;
            try
            {
                while (str[j] == '0')
                    j++;
            }
            catch (Exception e)
            {
                result = 0;
                return true;
            }
            

            for (int i = str.Length - 1; i >= j; i--)
            {
                long value;
                switch (str[i])
                {
                    case '0':
                        value = 0;
                        break;
                    case '1':
                        value = 1;
                        break;
                    case '2':
                        value = 2;
                        break;
                    case '3':
                        value = 3;
                        break;
                    case '4':
                        value = 4;
                        break;
                    case '5':
                        value = 5;
                        break;
                    case '6':
                        value = 6;
                        break;
                    case '7':
                        value = 7;
                        break;
                    case '8':
                        value = 8;
                        break;
                    case '9':
                        value = 9;
                        break;
                    case 'A':
                        value = 10;
                        break;
                    case 'B':
                        value = 11;
                        break;
                    case 'C':
                        value = 12;
                        break;
                    case 'D':
                        value = 13;
                        break;
                    case 'E':
                        value = 14;
                        break;
                    case 'F':
                        value = 15;
                        break;
                    default:
                        return false;

                }

                result += value * hex_pos;

                hex_pos *= 16;
            }

            return true;
        }
    }
}
