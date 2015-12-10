using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSVGenerator.Core
{
    public class CSVGenerator<T> : CSVGenerator, IDisposable
    {
        private readonly string mFilePath;
        private const int BUFFER_SIZE = 512 * 1024; // 512KB
        private Stream mFile;
        private StreamWriter mStreamWriter;
        private const char CSV_SEPARATOR = ';';

        public CSVGenerator(string filePath)
        {
            mFilePath = filePath;
        }

        private void CheckPreRequisites()
        {
            if (mFile != null) return;
            mFile = File.Create(mFilePath, BUFFER_SIZE);
            mStreamWriter = new StreamWriter(mFile, Encoding.UTF8);
        }

        public void WriteHeader<THeader>(THeader headerModel)
        {
            CheckPreRequisites();
            var orderedFields = GetOrderedModelCSVFields(typeof(THeader));
            WriteContentRowToFile(mStreamWriter, headerModel, orderedFields);
            mStreamWriter.Write(Environment.NewLine);
        }

        public void WriteContent(IList<T> itemList)
        {
            CheckPreRequisites();
            var orderedFields = GetOrderedModelCSVFields(typeof(T));
            WriteContentHeaderToFile(mStreamWriter, orderedFields);
            foreach (var model in itemList)
            {
                WriteContentRowToFile(mStreamWriter, model, orderedFields);
            }
        }

        private void WriteContentHeaderToFile(StreamWriter streamWriter, Tuple<PropertyInfo, CSVColumnAttribute>[] fieldList)
        {
            WriteNewLine(streamWriter, line =>
            {
                foreach (var field in fieldList)
                {
                    line.Append(field.Item2.HeaderText);
                    line.Append(CSV_SEPARATOR);
                }
            });
        }

        private void WriteContentRowToFile<TModel>(StreamWriter streamWriter, TModel model, Tuple<PropertyInfo, CSVColumnAttribute>[] fieldList)
        {
            WriteNewLine(streamWriter, line =>
            {
                foreach (var field in fieldList)
                {
                    var fieldValue = GetFormattedValue(model, field);
                    line.Append(fieldValue);
                    if (field.Item2.NewLineAfterPrint)
                    {
                        line.Append(Environment.NewLine);
                    }
                    else
                    {
                        line.Append(CSV_SEPARATOR);
                    }
                }
            });
        }

        private void WriteNewLine(StreamWriter streamWriter, Action<StringBuilder> writeContentAction)
        {
            var line = new StringBuilder();
            writeContentAction(line);
            var stringContent = line.ToString();
            if (string.IsNullOrEmpty(stringContent))
            {
                return;
            }
            streamWriter.WriteLine(stringContent.Substring(0, stringContent.Length - 1));
        }

        private string GetFormattedValue<TModel>(TModel model, Tuple<PropertyInfo, CSVColumnAttribute> field)
        {
            var value = field.Item1.GetValue(model);
            if (value == null)
            {
                return field.Item2.ValueIfNull;
            }
            // Unformatted value.
            if (string.IsNullOrEmpty(field.Item2.Format)) return value.ToString().Replace(CSV_SEPARATOR, ' ');

            if (field.Item1.PropertyType == typeof(DateTime))
            {
                var dateTimeValue = (DateTime)value;
                return dateTimeValue.ToString(field.Item2.Format);
            }
            if (field.Item1.PropertyType == typeof(decimal))
            {
                var decimalValue = (decimal)value;
                return decimalValue.ToString(field.Item2.Format);
            }
            if (field.Item1.PropertyType == typeof(string))
            {
                return string.Format(field.Item2.Format, value);
            }
            return value.ToString();
        }

        private Tuple<PropertyInfo, CSVColumnAttribute>[] GetOrderedModelCSVFields(Type type)
        {
            var csvColumnAttributeType = typeof(CSVColumnAttribute);
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(field => field.IsDefined(csvColumnAttributeType, false)) // Select only fields with the CSVColumnAttribute
                .Select(field => new Tuple<PropertyInfo, CSVColumnAttribute>(field, (CSVColumnAttribute)field.GetCustomAttribute(csvColumnAttributeType, false))) // Get CSVColumnAttribute value
                .OrderBy(tuple => tuple.Item2.Order).ToArray(); // Order by CSVColumnAttribute Order property.
        }

        public void Dispose()
        {
            mStreamWriter?.Dispose();
            mFile?.Dispose();
        }
    }

    public abstract class CSVGenerator
    {
        public const string DATE_FORMAT = "dd/MM/yyyy";
        public const string DECIMAL_FORMAT = "0.00";
        public const string DATE_FORMAT_WITH_TIME = "dd/MM/yyyy HH:mm";
    }
}
