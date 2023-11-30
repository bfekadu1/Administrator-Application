using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminstrator_Application.Model
{
    internal class configuration
    {
        public bool showBalance {  get; set; }
        public bool IsStoreMoving {  get; set; }
        public bool EnableToStore {  get; set; }
        public bool EnableFromStore {  get; set; }
        public bool MandatoryToStore {  get; set; }
        public bool MandatoryFromStore {  get; set; }
        public bool IsFlexibleDate {  get; set; }
        public bool IsFlexiblePeriod { get; set; }
        public bool AllowEmptyConsignee {  get; set; }
        public bool EnableNewConsignee { get; set; }
        public bool EnableBatch {  get; set; }
        public bool EnableProductionDate {  get; set; }
        public bool EnableExpireDate {  get; set; }
        public bool IsBacthSelectable {  get; set; }
        public bool EnableDirectPreparation {  get; set; }
        public bool EnableItemMaintenance {  get; set; }
        public bool ValueTaxInclusive {  get; set; }
        public bool ValueMandatoryPrice { get; set; }
        public bool EnableValue { get; set; }
        public bool ValueMandatory { get; set; }
    }
}
