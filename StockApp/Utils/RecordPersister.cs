using System;
using System.IO;
using System.Windows.Forms;

namespace StockApp.Utils
{
    class RecordPersister : IRecordPersister
    {
        public const string DataDir = @"Data";
        public const string RecordsFilename = @"records.txt";

        private static IRecordPersister instance;

        private RecordPersister()
        {
            if (!Directory.Exists(DataDir))
            {
                Directory.CreateDirectory(DataDir);
            }
        }

        public static IRecordPersister Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecordPersister();
                }
                return instance;
            }
        }

        public void AddRecord(string record)
        {
            string file = DataDir + "\\" + RecordsFilename;

            if (File.Exists(file) && file.Length > (8 * 1024 * 1024))
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Unable to create new stock record. File too big.", "", buttons);
                return;
            }

            bool hasFailed = false;
            string msg = string.Empty;

            try
            {
                SimpleValidator.CheckNullOrEmpty(record, "Record");

                string appendText = record + Environment.NewLine + new string('-', 23) + Environment.NewLine;
                File.AppendAllText(file, appendText);
            }
            catch (ArgumentException e)
            {
                hasFailed = true;
                msg = e.Message;
            }
            catch (PathTooLongException e)
            {
                hasFailed = true;
                msg = e.Message;
            }
            catch (DirectoryNotFoundException e)
            {
                hasFailed = true;
                msg = e.Message;
            }
            catch (IOException e)
            {
                hasFailed = true;
                msg = e.Message;
            }
            catch (UnauthorizedAccessException e)
            {
                hasFailed = true;
                msg = e.Message;
            }
            catch (NotSupportedException e)
            {
                hasFailed = true;
                msg = e.Message;
            }

            if (hasFailed)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Unable to add last Stock record", msg, buttons);
            }
        }

        public void ClearRecords()
        {
            throw new System.NotImplementedException();
        }

        public string GetRecords()
        {
            bool hasFailed = false;
            string msg = string.Empty;
            string result = string.Empty;

            try
            {
                result = File.ReadAllText(DataDir + "\\" + RecordsFilename);
            }
            catch (ArgumentException e)
            {
                hasFailed = true;
                msg = e.Message;
            }
            catch (PathTooLongException e)
            {
                hasFailed = true;
                msg = e.Message;
            }
            catch (DirectoryNotFoundException e)
            {
                hasFailed = true;
                msg = e.Message;
            }
            catch (IOException e)
            {
                hasFailed = true;
                msg = e.Message;
            }
            catch (UnauthorizedAccessException e)
            {
                hasFailed = true;
                msg = e.Message;
            }
            catch (NotSupportedException e)
            {
                hasFailed = true;
                msg = e.Message;
            }

            if (hasFailed)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Unable to read Stock records", msg, buttons);
            }

            return result;
        }
    }
}