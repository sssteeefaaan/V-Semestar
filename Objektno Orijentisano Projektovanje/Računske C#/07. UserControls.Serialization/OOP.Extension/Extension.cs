using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace OOP.Extension
{
    public static class Extension
    {
        public static string Serialize<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    writer.Settings.Indent = true;
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public static bool Serialize<T>(this T value, string path)
        {
            if (value == null)
            {
                return false;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));

                using (var fileWriter = new FileStream(path, FileMode.Create))
                {
                    xmlserializer.Serialize(fileWriter, value);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public static T DeSerialize<T>(this T value, string path)
        {
            T type;

            var serializer = new XmlSerializer(typeof(T));

            using (var reader = XmlReader.Create(path))
            {
                type = (T)serializer.Deserialize(reader);
            }

            return type;
        }
    }
}
