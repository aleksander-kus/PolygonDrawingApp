using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace lab1.Helpers
{
    public static class XMLHelper
    {
        private static bool invalid_xml = false;
        private static void ValidationHandler(Object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.WriteLine("Warning: {0}", args.Message);
            else
                Console.WriteLine("Error: {0}", args.Message);
            invalid_xml = true;
        }

        private static bool Validate(string xml_path, XmlReaderSettings settings)
        {
            invalid_xml = false;
            try
            {
                XmlReader reader = XmlReader.Create(xml_path, settings);
                while (reader.Read() && !invalid_xml) ;
                reader.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return !invalid_xml;
        }

        /// <summary>
        /// Check if the XML file complies with the XML Schema
        /// </summary>
        /// <param name="xml_path">Path to XML file to be validated</param>
        /// <param name="target_namespace">Target namespace of the schema</param>
        /// <param name="schema_path">Path to XML Schema</param>
        /// <returns><see cref="true"/> if file is valid, <see cref="false"/> otherwise</returns>
        public static bool ValidateXML(string xml_path, string target_namespace, string schema_path)
        {
            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.Schemas.Add(target_namespace, schema_path);
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationEventHandler += ValidationHandler;

            return Validate(xml_path, settings);
        }

        /// <summary>
        /// Check if the XML file complies with the XML Schema
        /// </summary>
        /// <param name="xml_path">Path to XML file to be validated</param>
        /// <param name="schema_path">String containing the schema</param>
        /// <returns><see cref="true"/> if file is valid, <see cref="false"/> otherwise</returns>
        public static bool ValidateXML(string xml_path, string schema_string)
        {
            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationEventHandler += ValidationHandler;
            XmlSchema schema = XmlSchema.Read(new StringReader(schema_string), null);
            settings.Schemas.Add(schema);

            return Validate(xml_path, settings);
        }

        /// <summary>
        /// Check if XML file complies with the XML Schema, which is an embedded resource
        /// For making the schema an embedded resource, right click on scheam file -> Properties -> Build Action -> Embedded Resource
        /// </summary>
        /// <param name="xml_path">Path to XML file to be validated</param>
        /// <param name="schema_location">Path to schema as embedded resource. For example projectname.SchemaFolder.schema.xsd</param>
        /// <returns></returns>
        public static bool ValidateXMLEmbedded(string xml_path, string schema_location)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(schema_location);
            using var reader = new StreamReader(stream);
            string result = reader.ReadToEnd();

            return ValidateXML(xml_path, result);
        }

        /// <summary>
        /// Deserialize an object from an XML file
        /// </summary>
        /// <typeparam name="T">Type of the root of XML file</typeparam>
        /// <param name="path">Path to XML file</param>
        /// <returns></returns>
        public static T ReadFromXML<T>(string path)
        {
            using var fs = new FileStream(path, FileMode.Open);
            var xs = new XmlSerializer(typeof(T));
            T ret = (T)xs.Deserialize(fs);
            return ret;
        }

        /// <summary>
        /// Deserialize an object from an XML file, which is an embedded resource
        /// </summary>
        /// <typeparam name="T">Type of the root of XML file</typeparam>
        /// <param name="path">Path to XML file</param>
        /// <returns></returns>
        public static T ReadFromXMLEmbedded<T>(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(path);
            var xs = new XmlSerializer(typeof(T));
            T ret = (T)xs.Deserialize(stream);

            return ret;
        }

        /// <summary>
        /// Serialize an object to an XML file
        /// </summary>
        /// <typeparam name="T">Type of object to serialize</typeparam>
        /// <param name="path">Path to XML file</param>
        /// <param name="data">Object to be serialized</param>
        public static void WriteToXML<T>(string path, T data)
        {
            using var fs = new FileStream(path, FileMode.Create);
            var xs = new XmlSerializer(typeof(T));
            xs.Serialize(fs, data);
        }

        // Auto-generate class files with this command:
        // PS> & "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\xsd.exe" /c path
    }
}
