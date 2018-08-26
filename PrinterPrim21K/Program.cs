using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DrvFRLib;
using ShtrihFR;
using CachType = System.Collections.Generic.Dictionary<System.UInt32, ShtrihFR.TLVReader.ТЛВОтчет>;

namespace PrinterPayonline
{
    public enum CheckType
    {
        Sale,
        Buy,
        ReturnSale,
        ReturnBuy
    }

    public enum StateType
    {
        ПринтерВРабочемРежиме,
        ВыдачаДанных,
        ОткрытаяСмена24ЧасаНеКончились,
        ОткрытаяСмена24ЧасаКончились,
        ЗакрытаяСмена,
        БлокировкаПоНеправильномуПаролюНалоговогоИнспектора,
        ОжиданиеПодтвержденияВводаДаты,
        РазрешениеИзмененияПоложенияДесятичнойТочки,
        ОткрытыйДокумент,
        РежимРазрешенияТехнологическогоОбнуления,
        ТестовыйПрогон,
        ПечатьПолногоФискальногоОтчета,
        ПечатьДлинногоОтчетаЭклз,
        РаботаСФискальнымПодкладнымДокументом,
        ПечатьПодкладногоДокумента,
        ФискальныйПодкладнойДокументСформирован
    }
    /// <summary>
    /// Положение штрихкода на чеке
    /// </summary>
    public enum BarcodePosition
    {
        /// <summary>
        /// Сверху
        /// </summary>
        Top = 0,
        /// <summary>
        /// Снизу
        /// </summary>
        Bottom = 1,
    }
    class Program
    {
        public static bool IsTest = true;
        public static int TaxType = 0;

        public static decimal Summ;
        public static double CommonDiscount = 0.04;
        private static string _txt = "Hello, from C#!";//Console.ReadLine();

        private static string _testMsg = $@"
------------------------------------
  Тестовая строка
  Проверка ручной печати

  4 строка: значение 1
  5 строка: значение 2
  6 строка: {_txt}
------------------------------------";

        private bool testResult(int Result, string OperationDescription = "")
        {
            if (Result != 0)
            {
                Console.Write(string.Format("ERROR {2} Результат: {0}, {1}", _driver.ResultCode, _driver.ResultCodeDescription, OperationDescription ?? ""));
            }
            return Result == 0;
        }

        private readonly DrvFR _driver;
        private readonly TLVReader _tlvReader;
        private readonly bool _printFull;
        public Program()
        {
            //DriveCacher<CachType>.SetLogger(Logger);
            _driver = new DrvFR();
            _tlvReader = new TLVReader(_driver);
            _printFull = true;
        }

        static void Main(string[] args)
        {
            var data = new CachType();
            data.Add(123, new TLVReader.ТЛВОтчет());
            data.Add(456, new TLVReader.ТЛВОтчет());

            if (DriveCacher<CachType>.Serialize(data))
            {
                var data2 = DriveCacher<CachType>.Deserialize();
            }
            var driver = new DrvFR();

            //PrintBar(msg);

            PrintStatus(driver);
            var tlvReader = new TLVReader(driver);
            //var doc = tlvReader.ReadTLVDoc(796/*GetLastDocNumber(driver)*/);

            if (GetStatus(driver) == StateType.ЗакрытаяСмена)
            {
                TestMode(driver, IsTest);
                Open(driver);
            }

            for (int i = 0; i < 1; ++i)
            {
                PrintStatus(driver);
                if (GetStatus(driver) == StateType.ОткрытаяСмена24ЧасаНеКончились)
                {
                    var cash = GetCash(driver);
                    Console.WriteLine($"Наличных в кассе: {cash}");
                    TestMode(driver, IsTest);
                    CashIncome(driver, 10016);
                    TestMode(driver, IsTest);
                    OpenCheck(driver, CheckType.Sale);
                }
                if (GetStatus(driver) == StateType.ОткрытыйДокумент)
                {
                    TestMode(driver, IsTest);
                    Sale(driver, 12.5, 126.58m, 1, $"Супер товар за {126.58m}");
                    Sale(driver, 10, 325.63m, 1, $"Супер товар за {325.63m}");
                    for (int j = 0; j < 2; ++j)
                        Sale(driver, 5, 36.12m, 1, $"Супер товар за {36.12m}");

                    decimal roundSumm = ((int) (Summ/100))*100;
                    decimal delta = (Summ - roundSumm);

                    if (delta > 0)
                        Discount(driver, delta);

                    SetCustomerEMail(driver, "milvus@e1.ru");

                    CloseCheck(driver, Math.Abs(Summ), $"Все хватит :{Math.Abs(Summ)}");
                    tlvReader.ReadTLVDoc(GetLastDocNumber(driver));
                }

                PrintStatus(driver);
                if (GetStatus(driver) == StateType.ОткрытаяСмена24ЧасаНеКончились)
                {
                    TestMode(driver, IsTest);
                    OpenCheck(driver, CheckType.ReturnSale);
                }
                if (GetStatus(driver) == StateType.ОткрытыйДокумент)
                {
                    TestMode(driver, IsTest);
                    for (int j = 0; j < 3; ++j)
                        ReturnSale(driver, 12.5, 12, 1, $"Супер товар возврат {12}");

                    PrintStatus(driver);

                    SetCustomerEMail(driver, "milvus@e1.ru");
                    CloseCheck(driver, Math.Abs(Summ), $"Все хватит :{Math.Abs(Summ)}");
                    tlvReader.ReadTLVDoc(GetLastDocNumber(driver));
                }
            }
            if (GetStatus(driver) == StateType.ОткрытаяСмена24ЧасаНеКончились)
            {
                TestMode(driver, IsTest);

                var cash = GetCash(driver);
                Console.WriteLine($"Наличных в кассе: {cash}");
                CashOutcome(driver, cash);
            }
            if (GetStatus(driver) == StateType.ОткрытаяСмена24ЧасаНеКончились)
            {
                TestMode(driver, IsTest);
                PrintReport(driver);
                PrintStatus(driver);

                TestMode(driver, IsTest);
                Close(driver);

                //for (int i = 666; i < 667; ++i)
                //{
                //doc = tlvReader.ReadTLVDoc(GetLastDocNumber(driver));
                //}

                TestMode(driver, IsTest);
                PrintCheck(driver, _testMsg, "01012323454567678989", BarcodePosition.Top);
            }

            Console.WriteLine($"Решение: {driver.ResultCode}, {driver.ResultCodeDescription}");
            Console.ReadLine();
        }

        private bool Open()
        {
            if (_driver == null || GetStatus() != StateType.ЗакрытаяСмена)
                return false;
            return testResult(_driver.OpenSession(), "OpenSession");
        }
        private bool Close()
        {
            if (_driver == null)
                return false;

            var stat = GetStatus();

            if (stat != StateType.ОткрытаяСмена24ЧасаНеКончились &&
                stat != StateType.ОткрытаяСмена24ЧасаКончились)
                return false;

            return testResult(_driver.PrintReportWithCleaning());
        }

        private bool OpenCheck(CheckType type)
        {
            if (_driver == null)
                return false;
            _driver.CheckType = (int)type;
            return testResult(_driver.OpenCheck(), "OpenCheck");
        }
        private bool Sale(TLVReader.PayType payType, double quantity, decimal price, int department, string name)
        {
            if (_driver == null)
                return false;
            _driver.Quantity = quantity;
            _driver.Price = price;
            _driver.Department = department;
            _driver.Tax1 = 0;
            _driver.Tax2 = 0;
            _driver.Tax3 = 0;
            _driver.Tax4 = 0;
            var taxStr = "";
            int tax = TaxType;
            switch (payType)
            {
                case TLVReader.PayType.Cash:
                    _driver.Tax1 = tax;
                    break;
                case TLVReader.PayType.PayCard:
                    _driver.Tax2 = tax;
                    break;
                case TLVReader.PayType.CreditCard:
                    _driver.Tax3 = tax;
                    break;
            }
            _driver.StringForPrinting = name;
            return testResult(_driver.Sale());
        }
        private bool ReturnSale(TLVReader.PayType payType, double quantity, decimal price, int department, string name)
        {
            if (_driver == null)
                return false;
            _driver.Quantity = quantity;
            _driver.Price = price;
            _driver.Department = department;
            _driver.Tax1 = 0;
            _driver.Tax2 = 0;
            _driver.Tax3 = 0;
            _driver.Tax4 = 0;
            var taxStr = "TaxType";
            int tax = TaxType;
            switch (payType)
            {
                case TLVReader.PayType.Cash:
                    _driver.Tax1 = tax;
                    break;
                case TLVReader.PayType.PayCard:
                    _driver.Tax2 = tax;
                    break;
                case TLVReader.PayType.CreditCard:
                    _driver.Tax3 = tax;
                    break;
            }
            _driver.StringForPrinting = name;

            return testResult(_driver.ReturnSale());
        }
        private bool CloseCheck(TLVReader.PayType payType, decimal summ, string name)
        {
            if (_driver == null)
                return false;
            _driver.Summ1 = 0;//сколько дал клиент
            _driver.Summ2 = 0;
            _driver.Summ3 = 0;
            _driver.Summ4 = 0;
            _driver.Tax1 = 0;
            _driver.Tax2 = 0;
            _driver.Tax3 = 0;
            _driver.Tax4 = 0;
            var taxStr = "TaxType";
            int tax = TaxType;
            switch (payType)
            {
                case TLVReader.PayType.Cash:
                    _driver.Summ1 = summ;
                    _driver.Tax1 = tax;
                    break;
                case TLVReader.PayType.PayCard:
                    _driver.Summ2 = summ;
                    _driver.Tax2 = tax;
                    break;
                case TLVReader.PayType.CreditCard:
                    _driver.Summ3 = summ;
                    _driver.Tax3 = tax;
                    break;
            }
            //Driver.DiscountOnCheck = CommonDiscount;
            _driver.StringForPrinting = name;
            return testResult(_driver.CloseCheck());
        }

        private bool WaitUntillPrint()
        {
            if (_driver == null)
                return false;

            _driver.ConnectionTimeout = 10000;
            _driver.WaitForPrintingDelay = 500;

            return testResult(_driver.WaitForPrinting(), "WaitUntillPrint");
        }
        private bool SetPrintMode(bool print)
        {
            print = !print;
            if (_driver == null)
                return false;
            _driver.TableNumber = 17;
            _driver.GetTableStruct();

            _driver.RowNumber = 1;
            _driver.FieldNumber = 7;
            _driver.GetFieldStruct();

            var type = _driver.FieldType;

            if (!type)
                _driver.ValueOfFieldInteger = Convert.ToInt32(print);
            else
                _driver.ValueOfFieldString = $"{Convert.ToInt32(print)}";

            var result = testResult(_driver.WriteTable());

            return result;
        }
        //private bool SetCheckHeaderMode(string str)
        //{
        //    if (Driver == null)
        //        return false;

        //    var lines = str.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        //    int row = 13 - lines.Length;
        //    bool result = true;
        //    for (int i = 0; i < 12; ++i)
        //    {
        //        Driver.TableNumber = 4;
        //        Driver.GetTableStruct();

        //        Driver.RowNumber = row;
        //        Driver.FieldNumber = 1;
        //        Driver.GetFieldStruct();

        //        Driver.ReadTable();
        //        var oldStr = Driver.ValueOfFieldString;

        //        Driver.ValueOfFieldString = "";
        //        result = testResult(Driver.WriteTable());
        //    }
        //    foreach (var line in lines)
        //    {
        //        Driver.TableNumber = 4;
        //        Driver.GetTableStruct();

        //        Driver.RowNumber = row;
        //        Driver.FieldNumber = 1;
        //        Driver.GetFieldStruct();

        //        Driver.ReadTable();
        //        var oldStr = Driver.ValueOfFieldString;

        //        Driver.ValueOfFieldString = line;
        //        result = testResult(Driver.WriteTable());

        //        if(row < 12)
        //            ++row;
        //    }

        //    return result;
        //}
        private StateType? GetStatus()
        {
            if (_driver == null)
                return null;
            if (testResult(_driver.GetECRStatus(), "GetStatus"))
            {
#if DEBUG
                Console.Write("GetStatus: " + ((StateType)_driver.ECRMode).ToString());
#endif
                return (StateType)_driver.ECRMode;
            }

            return null;
        }

        private bool PrintCheck(string msg, string bar, BarcodePosition BarcodePosition)
        {
            if (_driver == null)
                return false;

            if (BarcodePosition == BarcodePosition.Top && !string.IsNullOrWhiteSpace(bar))
            {
                PrintBar(bar);
                WaitUntillPrint();
            }

            var lines = msg.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                _driver.StringForPrinting = line;
                if (!testResult(_driver.PrintString(), "PrintCheck->StringForPrinting"))
                    break;
            }
            _driver.StringForPrinting = "";
            _driver.PrintString();
            WaitUntillPrint();

            if (BarcodePosition == BarcodePosition.Bottom && !string.IsNullOrWhiteSpace(bar))
            {
                PrintBar(bar);
                WaitUntillPrint();
            }

            _driver.CutType = true;
            _driver.CutCheck();
            return testResult(_driver.CutCheck(), "PrintCheck->Cut");
        }
        private bool PrintBar(string msg)
        {
            _driver.BarCode = msg;
            _driver.LineNumber = 75;
            _driver.BarcodeType = 2;
            _driver.BarWidth = 3;
            _driver.BarcodeAlignment = TBarcodeAlignment.baCenter;
            _driver.PrintBarcodeText = 1;

            //return testResult(Driver.PrintBarCode(), "PrintBarCode");
            return testResult(_driver.PrintBarcodeLine(), "PrintBarcodeLine");
            //return testResult(Driver.PrintBarcodeGraph(), "PrintBarcodeGraph");
        }
        private bool PrintString(string msg)
        {
            if (_driver == null)
                return false;

            bool result = false;

            var lines = msg.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                _driver.StringForPrinting = line;
                result = testResult(_driver.PrintString(), "PrintString");
                if (!result)
                    break;
            }

            return result;
        }























        public static void Open(DrvFR driver)
        {
            driver.Password = 30;
            driver.OpenSession();

            if (IsSuccess(driver) == 0)
            {
                Console.WriteLine("Сессия открыта:");
                WaitUntillPrint(driver);
            }
        }

        public static void Close(DrvFR driver)
        {
            PrintZReport(driver);
            //SaveZReport(driver);
        }

        public static void OpenCheck(DrvFR driver, CheckType type)
        {
            Summ = 0.0m;
            driver.Password = 30;
            driver.CheckType = (int)type;
            driver.OpenCheck();

            if (IsSuccess(driver) == 0)
            {
                Console.WriteLine($"Чек открыт на оператора: {driver.OperatorNumber}");
                WaitUntillPrint(driver);
            }
        }

        public static void Sale(DrvFR driver, double quantity, decimal price, int department, string name)
        {
            driver.Password = 30;
            driver.Quantity = quantity;
            driver.Price = price;
            driver.Department = department;
            driver.Tax1 = TaxType;
            driver.Tax2 = TaxType;
            driver.Tax3 = TaxType;
            driver.Tax4 = TaxType;
            driver.StringForPrinting = name;
            driver.Sale();
            if (IsSuccess(driver) == 0)
            {
                Console.WriteLine(
                    $"Продажа на: {price} х {quantity} = {(double)price * quantity} кассир: {driver.OperatorNumber}");
                Summ += price * (decimal)quantity;
            }
        }

        public static void ReturnSale(DrvFR driver, double quantity, decimal price, int department, string name)
        {
            driver.Password = 30;
            driver.Quantity = quantity;
            driver.Price = price;
            driver.Department = department;
            driver.Tax1 = TaxType;
            driver.Tax2 = TaxType;
            driver.Tax3 = TaxType;
            driver.Tax4 = TaxType;
            driver.StringForPrinting = name;

            driver.ReturnSale();

            if (IsSuccess(driver) == 0)
            {
                Console.WriteLine(
                    $"Возврат на: {price} х {quantity} = {(double)price * quantity} кассир: {driver.OperatorNumber}");
                Summ -= price * (decimal)quantity;
            }
        }

        public static void CloseCheck(DrvFR driver, decimal summ1, string name)
        {
            driver.Password = 30;
            driver.Summ1 = summ1;//сколько дал клиент
            driver.Summ2 = 0;
            driver.Summ3 = 0;
            driver.Summ4 = 0;
            driver.Tax1 = TaxType;
            driver.Tax2 = TaxType;
            driver.Tax3 = TaxType;
            driver.Tax4 = TaxType;
            driver.DiscountOnCheck = CommonDiscount;
            driver.StringForPrinting = name;
            driver.CloseCheck();

            if (IsSuccess(driver) == 0)
            {
                Console.WriteLine($"Чек закрыт, сдача: { driver.Change }");
                WaitUntillPrint(driver);
            }
        }

        public static void CashIncome(DrvFR driver, decimal cash)
        {
            driver.Password = 30;
            driver.Summ1 = cash;
            driver.CashIncome();

            if (IsSuccess(driver) == 0)
            {
                Console.WriteLine($"Внесены в кассу: { cash }");
                WaitUntillPrint(driver);
            }
        }

        public static void CashOutcome(DrvFR driver, decimal cash)
        {
            driver.Password = 30;
            driver.Summ1 = cash;
            driver.CashOutcome();

            if (IsSuccess(driver) == 0)
            {
                Console.WriteLine($"Изъяты из кассы: { cash }");
                WaitUntillPrint(driver);
            }
        }

        public static void Discount(DrvFR driver, decimal discount)
        {
            driver.Password = 30;
            //driver.Summ1 = discount;
            //driver.Summ2 = 0;
            //driver.Summ3 = 0;
            //driver.Summ4 = 0;
            //driver.Tax1 = TaxType;
            //driver.Tax2 = TaxType;
            //driver.Tax3 = TaxType;
            //driver.Tax4 = TaxType;
            //driver.Discount();
            driver.DiscountOnCheck = (double)discount;
            if (IsSuccess(driver) == 0)
            {
                Console.WriteLine($"Скидка в размере: { discount }");
                //Summ -= discount;
                WaitUntillPrint(driver);
            }
        }

        //public static void PrintCheck(DrvFR driver, string msg)
        //{
        //    IsSuccess(driver, true);

        //    var lines = msg.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        //    foreach (var line in lines)
        //    {
        //        driver.StringForPrinting = line;
        //        driver.PrintString();

        //        IsSuccess(driver, true);
        //    }

        //    if (IsSuccess(driver) == 0)
        //    {
        //        WaitUntillPrint(driver);
        //    }
        //    driver.CutType = true;
        //    driver.CutCheck();
        //    IsSuccess(driver);
        //}

        private static bool PrintCheck(DrvFR driver, string msg, string bar, BarcodePosition BarcodePosition)
        {
            if (driver == null)
                return false;

            bool result = false;
            if (BarcodePosition == BarcodePosition.Top && !string.IsNullOrWhiteSpace(bar))
            {
                result = PrintBar(driver, bar);

                if (!result)
                    return result;

                WaitUntillPrint(driver);
            }

            var lines = msg.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                driver.StringForPrinting = line;
                result = testResult(driver, driver.PrintString());
                if (!result)
                    break;
            }
            if (result)
            {
                WaitUntillPrint(driver);
            }

            if (BarcodePosition == BarcodePosition.Bottom && !string.IsNullOrWhiteSpace(bar))
            {
                result = PrintBar(driver, bar);

                if (!result)
                    return result;

                WaitUntillPrint(driver);
            }

            driver.CutType = true;
            driver.CutCheck();
            return testResult(driver, driver.CutCheck(), "PrintCheck");
        }
        private static bool PrintBar(DrvFR driver, string msg)
        {
            driver.Password = 30;
            driver.BarCode = msg;
            driver.LineNumber = 75;
            driver.BarcodeType = 2;
            driver.BarWidth = 2;
            driver.BarcodeAlignment = TBarcodeAlignment.baCenter;
            driver.PrintBarcodeText = 1;

            //driver.PrintBarCode();
            return testResult(driver, driver.PrintBarcodeGraph(), "PrintBarcodeGraph"); ;
        }

        public static void PrintZReport(DrvFR driver)
        {
            driver.Password = 30;
            driver.PrintReportWithCleaning();

            if (IsSuccess(driver) == 0)
            {
                Console.WriteLine("Печать отчета с закрытием:");
                WaitUntillPrint(driver);
            }
        }
        
        public static void SaveZReport(DrvFR driver)
        {
            driver.Password = 30;
            driver.FNCloseSession();

            if (IsSuccess(driver) == 0)
            {
                Console.WriteLine("Сохранение отчета с закрытием:");
                WaitUntillPrint(driver);
            }
        }

        public static void PrintReport(DrvFR driver)
        {
            driver.Password = 30;
            driver.PrintReportWithoutCleaning();

            if (IsSuccess(driver) == 0)
            {
                Console.WriteLine("Печать отчета:");
                WaitUntillPrint(driver);
            }
        }

        public static void SetCustomerEMail(DrvFR driver, string mail)
        {
            if (string.IsNullOrWhiteSpace(mail))
                return;

            driver.Password = 30;
            driver.CustomerEmail = mail;
            driver.FNSendCustomerEmail();

            if (IsSuccess(driver) == 0)
            {
                Console.WriteLine($"Мыло установлено: {mail}!:");
                WaitUntillPrint(driver);
            }
        }

        public static void TestMode(DrvFR driver, bool test)
        {
            driver.Password = 30;
            driver.TableNumber = 17;
            driver.GetTableStruct();

            driver.Password = 30;
            driver.RowNumber = 1;
            driver.FieldNumber = 7;
            driver.GetFieldStruct();

            IsSuccess(driver);
            //else
            //    Console.WriteLine($"Поле: {driver.FieldName}, {driver.FieldType}, {driver.FieldSize}, {driver.MINValueOfField}, {driver.MAXValueOfField }");

            driver.Password = 30;

            var type = driver.FieldType;
            driver.ReadTable();
            int oldVal1 = 0;
            string oldVal2 = "";

            if (!type)
                oldVal1 = driver.ValueOfFieldInteger;
            else
                oldVal2 = driver.ValueOfFieldString;

            IsSuccess(driver);

            if (!type)
                driver.ValueOfFieldInteger = Convert.ToInt32(test);
            else
                driver.ValueOfFieldString = $"{Convert.ToInt32(test)}";

            int val1 = 0;
            string val2 = "";

            driver.WriteTable();
            driver.GetFieldStruct();
            driver.ReadTable();
            if (!type)
                val1 = driver.ValueOfFieldInteger;
            else
                val2 = driver.ValueOfFieldString;

            if (IsSuccess(driver) == 0)
                Console.WriteLine($"Значение установлено: c {(type ? oldVal2 : (oldVal1.ToString()))} на {(type ? val2 : (val1.ToString()))}");
        }

        public static void WaitUntillPrint(DrvFR driver)
        {
            driver.Password = 30;
            driver.ConnectionTimeout = 10000;
            driver.WaitForPrintingDelay = 500;
            driver.WaitForPrinting();

            IsSuccess(driver);
            //else
            //    Console.WriteLine($"Ожидание печати...");
        }

        public static StateType? GetStatus(DrvFR driver)
        {
            driver.Password = 30;
            driver.GetECRStatus();
            if (IsSuccess(driver, true) != 0)
                return null;
            return (StateType)driver.ECRMode;
        }

        public static decimal GetCash(DrvFR driver)
        {
            driver.Password = 30;
            driver.RegisterNumber = 241;
            driver.GetCashReg();
            if (IsSuccess(driver) != 0)
            {
                return 0;
            }
            return driver.ContentsOfCashRegister/*100*/;
        }

        public static int IsSuccess(DrvFR driver, bool print = true)
        {
            if (driver.ResultCode != 0)
            {
                if (print)
                    Console.WriteLine($"Ошибка: {driver.ResultCode}, {driver.ResultCodeDescription}");
                return driver.ResultCode;
            }
            return 0;
        }

        public static void PrintStatus(DrvFR driver)
        {
            Console.WriteLine($"Status:{GetStatus(driver)}");
        }
        private static bool testResult(DrvFR driver, int Result, string OperationDescription = "")
        {
            if (Result != 0)
            {
                Console.Write(string.Format("{2} Результат: {0}, {1}", driver.ResultCode, driver.ResultCodeDescription, OperationDescription ?? ""));
            }
            return Result == 0;
        }

        private static int GetLastDocNumber(DrvFR driver)
        {
            if (driver == null)
                return -1;

            var result = testResult(driver, driver.FNGetStatus(), "FNGetStatus");
            if (!result)
                return -1;

            return driver.DocumentNumber;
        }
    }
}