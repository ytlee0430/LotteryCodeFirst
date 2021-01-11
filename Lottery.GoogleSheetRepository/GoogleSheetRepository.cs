using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;

namespace Lottery.GoogleSheetRepository
{
    public class GoogleSheetRepository
    {
        public bool CreateNewSheet<T>(IEnumerable<T> list, string path) where T : class
        {
            try
            {
                string[] Scopes = { SheetsService.Scope.Spreadsheets };
                string ApplicationName = "GoogleSheetsTest";

                UserCredential credential;

                using (var stream =
                    new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }

                // Create Google Sheets API service.
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                var myNewSheet = new Spreadsheet
                {
                    Properties = new SpreadsheetProperties { Title = $"New Sheet" }
                };
                var googleNewSheet = service.Spreadsheets.Create(myNewSheet).Execute();

                // Define request parameters.
                String spreadsheetId = googleNewSheet.SpreadsheetId;
                String range = $"A:Z";

                SpreadsheetsResource.ValuesResource.AppendRequest request =
                    service.Spreadsheets.Values.Append(new ValueRange() { Values = ToDisplayDataList(list) }, spreadsheetId, range);
                request.InsertDataOption = SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum.INSERTROWS;
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;
                var response = request.Execute();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static IList<IList<Object>> ToDisplayDataList<T>(IEnumerable<T> list)
        {
            List<IList<Object>> objNewRecords = new List<IList<Object>>();
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            IList<Object> title = new List<Object>();
            foreach (var prop in props)
            {
                var attributes = prop.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                if (!attributes.Any())
                    title.Add(prop.Name);
                else
                {
                    var displayName = attributes.Cast<DisplayNameAttribute>().Single().DisplayName;
                    title.Add(String.IsNullOrEmpty(displayName) ? prop.Name : displayName);
                }
            }
            objNewRecords.Add(title);

            foreach (var l in list)
            {
                IList<Object> obj = new List<Object>();
                foreach (PropertyInfo pro in l.GetType().GetProperties())
                {
                    var Value = pro.GetValue(l, null);
                    obj.Add(Value.ToString());
                }
                objNewRecords.Add(obj);
            }

            return objNewRecords;
        }
    }
}
