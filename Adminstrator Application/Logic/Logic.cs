using Adminstrator_Application.Admin_App_DataAccess;
using Adminstrator_Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminstrator_Application.Logic
{
    public class Logic
    {
        List<IdDefination> idDefinations = new List<IdDefination>();
        List<IdValue> IdmaxValue = new List<IdValue>();
        List<IdValue> currentValue = new List<IdValue>();
        DataAccess dataAcess = new DataAccess();

        public string GenerateId(int type)
        {
            string idPrefix = "";
            string idSuffix = "";
            int leng = 0;
            int frontLeng = 0;
            int incrementedValue = 0;
            string maxId = "";
            string IncrementedMaxId = "";
            string id = "";
            //idValues=dataAcess.GetIdValues(); 
            idDefinations = dataAcess.GetIdDefinations();
            var selectedIdDefination = idDefinations.Where(idDefination => idDefination.type == type);
            //IdmaxValue = dataAcess.GetLastIdValue(selectedIdDefination[0].); //retrive the last id value from the database
            foreach (var maxValue in IdmaxValue)
            {
                if (maxValue.current_value != "")
                {
                    foreach (var selectedId in selectedIdDefination)
                    {
                        frontLeng = selectedId.prefix.Trim().Length + selectedId.prefix_separator.Trim().Length;
                        leng = selectedId.length;
                        idPrefix = selectedId.prefix.Trim() + selectedId.prefix_separator.Trim();
                        idSuffix = selectedId.suffix_separator.Trim() + selectedId.suffix.Trim();
                    }
                    maxId = maxValue.current_value.Substring(frontLeng, leng);
                    incrementedValue = int.Parse(maxId) + 1;
                    maxId = incrementedValue.ToString().PadLeft(leng, '0');
                    IncrementedMaxId = string.Format($"{idPrefix}" + $"{maxId}" + $"{idSuffix}");

                    IdValue idValue = new IdValue
                    {
                        id = maxValue.id + 1,
                        defination = type,
                        current_value = IncrementedMaxId,
                    };
                    IdmaxValue.Add(idValue);
                    return IncrementedMaxId;
                }
                else
                {

                    foreach (var selectedId in selectedIdDefination)
                    {
                        int[] length = new int[selectedId.length];
                        id = selectedId.prefix.Trim() + selectedId.prefix_separator.Trim();
                        for (var i = 0; i < length.Length; i++)
                        {
                            length[i] = 0;
                            id += length[i];
                        }

                        if (length.Length > 0)
                        {
                            id = id + selectedId.suffix_separator.Trim() + selectedId.suffix.Trim();
                            return id;
                        }
                    }
                    return id;
                }
            }
            return id;
        }
        public string UpdateId(int type, string id)
        {
            string idPrefix = "";
            string idSuffix = "";
            int leng = 0;
            int frontLeng = 0;
            int incrementedValue = 0;
            string IncrementedMaxId = "";
            var selectedIdDefination = idDefinations.Where(idDefination => idDefination.type == type);

            foreach (var selectedId in selectedIdDefination)
            {
                frontLeng = selectedId.prefix.Trim().Length + selectedId.prefix_separator.Trim().Length;
                leng = selectedId.length;
                idPrefix = selectedId.prefix.Trim() + selectedId.prefix_separator.Trim();
                idSuffix = selectedId.suffix_separator.Trim() + selectedId.suffix.Trim();
            }
            id = id.Substring(frontLeng, leng);
            incrementedValue = int.Parse(id) + 1;
            id = incrementedValue.ToString().PadLeft(leng, '0');
            IncrementedMaxId = string.Format($"{idPrefix}" + $"{id}" + $"{idSuffix}");
            return IncrementedMaxId;
        }

        public bool ValidateField(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            else
            {
                return true;
            }
        }
    }
}
