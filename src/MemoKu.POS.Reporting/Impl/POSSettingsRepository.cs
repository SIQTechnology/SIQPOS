using System.IO;
using MemoKu.POS.Reporting.Configurations;
using MemoKu.POS.Reporting.Models;
using MemoKu.POS.Utils;
using Newtonsoft.Json;

namespace MemoKu.POS.Reporting
{
    public class POSSettingRepository : IPOSSettingRepository
    {
        public POSSetting Get()
        {
            if (!File.Exists(POSSettingConfiguration.Filename))
            {
                POSSetting posSync = new POSSetting();
                Write(posSync);

                return posSync;
            }
            else
            {
                POSSetting result = new POSSetting();
                using (StreamReader sr = new StreamReader(POSSettingConfiguration.Filename))
                {
                    string posSyncJson = sr.ReadToEnd().DecryptString();
                    result = JsonConvert.DeserializeObject<POSSetting>(posSyncJson);
                }
                return result;
            }
        }

        public bool IsHasBeenLoggedIn()
        {
            POSSetting setting = Get();
            return setting.HasBeenLoggedIn;
        }

        public void SetToLoggedIn()
        {
            POSSetting setting = Get();
            setting.LoggedIn();
            Write(setting);
        }

        public void Save(POSSetting setting)
        {
            Write(setting);
        }

        private void Write(POSSetting posSetting)
        {
            string posSyncJson = JsonConvert.SerializeObject(posSetting);
            using (StreamWriter sw = new StreamWriter(POSSettingConfiguration.Filename))
            {
                sw.Write(posSyncJson.EncryptToString());
                sw.Flush();
                sw.Close();
            }
        }
    }
}
