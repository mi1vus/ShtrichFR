using System;
using System.ComponentModel;
using DrvFRLib;

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
        Принтер_в_рабочем_режиме,
        Выдача_данных,
        Открытая_смена_24_часа_не_кончились,
        Открытая_смена_24_часа_кончились,
        Закрытая_смена,
        Блокировка_по_неправильному_паролю_налогового_инспектора,
        Ожидание_подтверждения_ввода_даты,
        Разрешение_изменения_положения_десятичной_точки,
        Открытый_документ,
        Режим_разрешения_технологического_обнуления,
        Тестовый_прогон,
        Печать_полного_фискального_отчета,
        Печать_длинного_отчета_ЭКЛЗ,
        Работа_с_фискальным_подкладным_документом,
        Печать_подкладного_документа,
        Фискальный_подкладной_документ_сформирован
    }

class Program
    {
        private static object val12;

        static void Main(string[] args)
        {
            string txt = "Hello, from C#!";//Console.ReadLine();
            var Driver = new DrvFR();
            
            Console.WriteLine($"Status:{(StateType)GetStatus(Driver)}");
            TestMode(Driver, true);
            Open(Driver);

            //Driver.ShowProperties();
            //Driver.FontCount()
            Console.WriteLine($"Status:{(StateType)GetStatus(Driver)}");
            OpenCheck(Driver, CheckType.Sale);
            Sale(Driver, 12.5,124.58m,1);
            Sale(Driver, 10, 325.63m, 1);
            Sale(Driver, 5, 36.12m, 1);
            CloseCheck(Driver);
            Console.WriteLine($"Status:{(StateType)GetStatus(Driver)}");
            OpenCheck(Driver, CheckType.ReturnSale);
            ReturnSale(Driver, 12.5, 124, 1);
            Console.WriteLine($"Status:{(StateType)GetStatus(Driver)}");
            CloseCheck(Driver);

            PrintZReport(Driver);
            Console.WriteLine($"Status:{(StateType)GetStatus(Driver)}");
            WaitUntillPrint(Driver);
            PrintReport(Driver);

            PrintCheck(Driver,
$@"
------------------------------------
  Тестовая строка
  Проверка ручной печати

  4 строка: значение 1
  5 строка: значение 2
  6 строка: {txt}
------------------------------------"
);

            Console.WriteLine($"Решение: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            Console.ReadLine();
        }

        public static void Open(DrvFR Driver)
        {
            Driver.Password = 30;
            Driver.OpenSession();

            if (Driver.ResultCode != 0)
                Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            else
                Console.WriteLine("Сессия открыта:");
            WaitUntillPrint(Driver);
        }

        public static void OpenCheck(DrvFR Driver, CheckType type)
        {
            Driver.Password = 30;
            Driver.CheckType = (int)type;
            Driver.OpenCheck();

            if (Driver.ResultCode != 0)
                Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            else
                Console.WriteLine($"Чек открыт на оператора: {Driver.OperatorNumber}");
            WaitUntillPrint(Driver);
        }
        public static void Sale(DrvFR Driver, double quantity, decimal price, int department)
        {
            Driver.Password = 30;
            Driver.Quantity= quantity;
            Driver.Price = price;
            Driver.Department = department;
            Driver.Tax1 = 1;
            Driver.Tax2 = 2;
            Driver.Tax3 = 3;
            Driver.Tax4 = 4;
            Driver.StringForPrinting = $"Супер товар за {price}";
            Driver.Sale();

            if (Driver.ResultCode != 0)
                Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            else
                Console.WriteLine($"Продажа на: {price} х {quantity} = {(double)price * quantity} кассир: {Driver.OperatorNumber}");

        }
        public static void ReturnSale(DrvFR Driver, double quantity, decimal price, int department)
        {
            Driver.Password = 30;
            Driver.Quantity = quantity;
            Driver.Price = price;
            Driver.Department = department;
            Driver.Tax1 = 1;
            Driver.Tax2 = 2;
            Driver.Tax3 = 3;
            Driver.Tax4 = 4;
            Driver.StringForPrinting = $"Супер товар возврат {price}";

            Driver.ReturnSale();

            if (Driver.ResultCode != 0)
                Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            else
                Console.WriteLine($"Возврат на: {price} х {quantity} = {(double)price * quantity} кассир: {Driver.OperatorNumber}");

        }
        public static void CloseCheck(DrvFR Driver)
        {
            Driver.Password = 30;
            Driver.Summ1 = 10000;
            Driver.CloseCheck();

            if (Driver.ResultCode != 0)
                Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            else
                Console.WriteLine($"Чек закрыт, сдача: { Driver.Change }");
            WaitUntillPrint(Driver);
        }

        public static void PrintCheck(DrvFR Driver, string msg)
        {
            Driver.Password = 30;
            var lines = msg.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                Driver.StringForPrinting = line;
                Driver.PrintString();

                if (Driver.ResultCode != 0)
                    Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            }
            WaitUntillPrint(Driver);
            Driver.CutType = true;
            Driver.CutCheck();
        }
        public static void PrintZReport(DrvFR Driver)
        {
            Driver.Password = 30;
            Driver.PrintReportWithCleaning();

            if (Driver.ResultCode != 0)
                Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            else
                Console.WriteLine("Печать отчета:");
            WaitUntillPrint(Driver);
        }
        public static void PrintReport(DrvFR Driver)
        {
            Driver.Password = 30;
            Driver.PrintReportWithoutCleaning();

            if (Driver.ResultCode != 0)
                Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            else
                Console.WriteLine("Печать отчета:");
            WaitUntillPrint(Driver);
        }

        public static void TestMode(DrvFR Driver, bool test)
        {
            Driver.Password = 30;
            Driver.TableNumber = 17;
            Driver.GetTableStruct();

            Driver.Password = 30;
            Driver.RowNumber = 1;
            Driver.FieldNumber = 7;
            Driver.GetFieldStruct();

            if (Driver.ResultCode != 0)
                Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            else
                Console.WriteLine($"Поле: {Driver.FieldName}, {Driver.FieldType}, {Driver.FieldSize}, {Driver.MINValueOfField}, {Driver.MAXValueOfField }");

            Driver.Password = 30;

            var type = Driver.FieldType;
            Driver.ReadTable();
            int val1 = 0;
            string val2 = "";

            if (!type)
                val1 = Driver.ValueOfFieldInteger;
            else
                val2 = Driver.ValueOfFieldString;

            if (Driver.ResultCode != 0)
                Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            else
                Console.WriteLine($"Значение: {(type ? val2 : (val1.ToString()))}");

            if (!type)
                Driver.ValueOfFieldInteger = Convert.ToInt32(test);
            else
                Driver.ValueOfFieldString = $"{Convert.ToInt32(test)}";
			
            Driver.WriteTable();
            Driver.GetFieldStruct();
            Driver.ReadTable();
            if (!type)
                val1 = Driver.ValueOfFieldInteger;
            else
                val2 = Driver.ValueOfFieldString;

            if (Driver.ResultCode != 0)
                Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            else
                Console.WriteLine($"Значение установлено: {(type ? val2 : (val1.ToString()))}");
        }

        public static void WaitUntillPrint(DrvFR Driver)
        {
            Driver.Password = 30;
            Driver.ConnectionTimeout = 10000;
            Driver.WaitForPrintingDelay = 1000;
            Driver.WaitForPrinting();

            if (Driver.ResultCode != 0)
                Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
            else
                Console.WriteLine($"Ожидание печати...");

        }
        public static int GetStatus(DrvFR Driver)
        {
            Driver.Password = 30;
            Driver.GetECRStatus();
            if (Driver.ResultCode != 0)
            {
                Console.WriteLine($"Ошибка: {Driver.ResultCode}, {Driver.ResultCodeDescription}");
                return -1;
            }
            return Driver.ECRMode;
        }

    }
}