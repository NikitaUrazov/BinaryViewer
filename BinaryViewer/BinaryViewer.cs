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

        /// <summary>
        /// Метод, читающий файл и сохраняющий содержимое в бинарном виде в результирующем файле.
        /// </summary>
        /// <param name="file">Файл для прочтения</param>
        static public void Read(string file)
        {
            FileStream source = new FileStream(file, FileMode.Open, FileAccess.Read);
            FileStream result = new FileStream(Result, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(result);
            StringBuilder sb = new StringBuilder();

            try
            {
                const long bytesChunkSize = 16;
                byte[] bytesChunk = new byte[bytesChunkSize];

                while (source.Position != source.Length)
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

                    sw.WriteLine(sb.ToString());
                }

                sw.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                source.Dispose();
                result.Dispose();
                sw.Dispose();
            }
        }

        /// <summary>
        /// Метод возвращает позицию смещения в результирующем файле.
        /// </summary>
        /// <param name="offset">Смещение, позицию которого необходимо найти.</param>
        /// <returns></returns>
        static public long GetOffsetPosition(long offset)
        {
            if (offset < 0)
                return -1;

            long position = 0;
            using (StreamReader sr = new StreamReader(Result))
            {
                string s = null;

                //Поиск строки, содержащей нужное смещение. Каждая строка Содержит 16 байт начального файла.

                //Текущее смещение
                long currentOffset = 0;
                //Булевая переменная отвечающая за то, находится ли смещение в текущем файле.
                //Если будут прочитаны все строки файла и смещение не найдено - false
                //При нахождении строки содержащей смещение - true
                bool offsetPresent = false;

                while (!sr.EndOfStream)
                {
                    if (currentOffset + 16 > offset)
                    {
                        offsetPresent = true;
                        break;
                    }
                    else
                    {
                        s = sr.ReadLine();
                        position += s.Length + 2;
                        currentOffset += 16;
                    }

                }

                if (!offsetPresent)
                    return -1;

                //Если смещение находится в первой строке, то в цикле выше не происходит чтение строки
                //и s - пустая. Эта проверка для такого случая.
                if (s == null)
                    s = sr.ReadLine();

                //Поиск нужного смещения в строке. i отвечает за перебор элементов в строке.
                //j отвечает за счёт байт оригинального файла, представленных в строке. Счёт
                //идёт по пробелам перед байтом.
                for (int i = 0, j = -1; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        j++;
                        //Если нужное смещение найдено.
                        if (j == offset % 16)
                        {
                            position += i + 1;
                            return position;
                        }
                    }
                }

            }

            return -1;
        }
    }
}
