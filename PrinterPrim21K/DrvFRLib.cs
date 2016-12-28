using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DrvFRLibMy
{
    public enum TBarcodeAlignment
    {
        baCenter,
        baLeft,
        baRight,
    }

    public class DrvFR
    {

        public extern int AddLD();


        public extern int Beep();


        public extern int Buy();


        public extern int BuyEx();


        public extern int CancelCheck();


        public extern int CashIncome();


        public extern int CashOutcome();


        public extern int Charge();


        public extern int CheckSubTotal();


        public extern int CloseCheck();


        public extern int ConfirmDate();


        public extern int Connect();


        public extern int ContinuePrint();


        public extern int Correction();


        public extern int CutCheck();


        public extern int DampRequest();


        public extern int DeleteLD();


        public extern int Disconnect();


        public extern int Discount();


        public extern int DozeOilCheck();


        public extern int Draw();


        public extern int EKLZDepartmentReportInDatesRange();


        public extern int EKLZDepartmentReportInSessionsRange();


        public extern int EKLZJournalOnSessionNumber();


        public extern int EKLZSessionReportInDatesRange();


        public extern int EKLZSessionReportInSessionsRange();


        public extern int ExchangeBytes();


        public extern int FeedDocument();


        public extern int Fiscalization();


        public extern int FiscalReportForDatesRange();


        public extern int FiscalReportForSessionRange();


        public extern int GetActiveLD();


        public extern int EnumLD();


        public extern int GetCashReg();


        public extern int GetCountLD();


        public extern int GetData();


        public extern int GetDeviceMetrics();


        public extern int GetECRStatus();


        public extern int GetShortECRStatus();


        public extern int GetExchangeParam();


        public extern int GetFieldStruct();


        public extern int GetFiscalizationParameters();


        public extern int GetFMRecordsSum();


        public extern int GetLastFMRecordDate();


        public extern int GetLiterSumCounter();


        public extern int GetOperationReg();


        public extern int GetParamLD();


        public extern int GetRangeDatesAndSessions();


        public extern int GetRKStatus();


        public extern int GetTableStruct();


        public extern int InitFM();


        public extern int InitTable();


        public extern int InterruptDataStream();


        public extern int InterruptFullReport();


        public extern int InterruptTest();


        public extern int LaunchRK();


        public extern int LoadLineData();


        public extern int OilSale();


        public extern int OpenCheck();


        public extern int OpenDrawer();


        public extern int PrintBarCode();


        public extern int PrintDepartmentReport();


        public extern int PrintDocumentTitle();


        public extern int PrintOperationReg();


        public extern int PrintReportWithCleaning();


        public extern int PrintReportWithoutCleaning();


        public extern int PrintString();


        public extern int PrintWideString();


        public extern int ReadEKLZDocumentOnKPK();


        public extern int ReadEKLZSessionTotal();


        public extern int ReadLicense();


        public extern int ReadTable();


        public extern int RepeatDocument();


        public extern int ResetAllTRK();


        public extern int ResetRK();


        public extern int ResetSettings();


        public extern int ResetSummary();


        public extern int ReturnBuy();


        public extern int ReturnBuyEx();


        public extern int ReturnSale();


        public extern int ReturnSaleEx();


        public extern int Sale();


        public extern int SaleEx();


        public extern int SetActiveLD();


        public extern int SetDate();


        public extern int SetDozeInMilliliters();


        public extern int SetDozeInMoney();


        public extern int SetExchangeParam();


        public extern int SetParamLD();


        public extern int SetPointPosition();


        public extern int SetRKParameters();


        public extern int SetSerialNumber();


        public extern int SetTime();


        public extern int ShowProperties();


        public extern int StopEKLZDocumentPrinting();


        public extern int StopRK();


        public extern int Storno();


        public extern int StornoEx();


        public extern int StornoCharge();


        public extern int StornoDiscount();


        public extern int SummOilCheck();


        public extern int SysAdminCancelCheck();


        public extern int Test();


        public extern int WriteLicense();


        public extern int WriteTable();


        public extern int PrintStringWithFont();


        public extern int EKLZActivizationResult();


        public extern int EKLZActivization();


        public extern int CloseEKLZArchive();


        public extern int GetEKLZSerialNumber();


        public extern int EKLZInterrupt();


        public extern int GetEKLZCode1Report();


        public extern int GetEKLZCode2Report();


        public extern int TestEKLZArchiveIntegrity();


        public extern int GetEKLZVersion();


        public extern int InitEKLZArchive();


        public extern int GetEKLZData();


        public extern int GetEKLZJournal();


        public extern int GetEKLZDocument();


        public extern int GetEKLZDepartmentReportInDatesRange();


        public extern int GetEKLZDepartmentReportInSessionsRange();


        public extern int GetEKLZSessionReportInDatesRange();


        public extern int GetEKLZSessionReportInSessionsRange();


        public extern int GetEKLZSessionTotal();


        public extern int GetEKLZActivizationResult();


        public extern int SetEKLZResultCode();


        public extern int OpenFiscalSlipDocument();


        public extern int OpenStandardFiscalSlipDocument();


        public extern int RegistrationOnSlipDocument();


        public extern int StandardRegistrationOnSlipDocument();


        public extern int ChargeOnSlipDocument();


        public extern int StandardChargeOnSlipDocument();


        public extern int CloseCheckOnSlipDocument();


        public extern int StandardCloseCheckOnSlipDocument();


        public extern int ConfigureSlipDocument();


        public extern int ConfigureStandardSlipDocument();


        public extern int FillSlipDocumentWithUnfiscalInfo();


        public extern int ClearSlipDocumentBufferString();


        public extern int ClearSlipDocumentBuffer();


        public extern int PrintSlipDocument();


        public extern int DiscountOnSlipDocument();


        public extern int StandardDiscountOnSlipDocument();


        public extern int EjectSlipDocument();


        public extern int LoadLineDataEx();


        public extern int DrawEx();


        public extern int ConfigureGeneralSlipDocument();


        public extern int WideLoadLineData();


        public extern int PrintTaxReport();


        public extern int GetLongSerialNumberAndLongRNM();


        public extern int SetLongSerialNumber();


        public extern int FiscalizationWithLongRNM();


        public extern int Connect2();


        public extern int GetECRPrinterStatus();


        public extern int ServerConnect();


        public extern int ServerDisconnect();


        public extern int LockPort();


        public extern int UnlockPort();


        public extern int AdminUnlockPort();


        public extern int AdminUnlockPorts();


        public extern int ServerCheckKey();


        public extern int GetFontMetrics();


        public extern int GetFreeLDNumber();


        public extern void SetIsString([In] bool Value);


        public extern void SetFieldSize([In] int Value);


        public extern int ReadTable2();


        public extern int WriteTable2();


        public extern int CashControlOpen();


        public extern int CashControlClose();


        public extern int SaveParams();


        public extern int GetEKLZCode1Status();


        public extern int GetEKLZCode2Status();


        public extern int ReadWriteFM();


        public extern int PrintHeader();


        public extern int CloseCheckWithResult();


        public extern int AboutBox();


        public extern int PresenterKeep();


        public extern int PresenterPush();


        public extern int OpenScreen();


        public extern int CloseScreen();


        public extern int SetSCPassword();


        public extern bool MethodSupported();


        public extern bool PropertySupported();


        public extern int LockPortTimeout();


        public extern int GetIBMStatus();


        public extern int GetShortIBMStatus();


        public extern int GetCommandParams();


        public extern int SetCommandParams();


        public extern int SaveCommandParams();


        public extern int SetAllCommandsParams();


        public extern int SetDefCommandsParams();


        public extern int GetInterval();


        public extern int OpenSession();


        public extern int ReprintSlipDocument();


        public extern int SetInterval();


        public extern int ShowPayParams();


        public extern int ShowTablesDlg();


        public extern int WaitForPrinting();


        public extern int OutputReceipt();


        public extern int Sale2();


        public extern int CardPayProperties();


        public extern int PrintCliche();


        public extern int PrintLine();


        public extern int PrintBarcodeLine();


        public extern int PrintBarcodeGraph();


        public extern int ResetECR();


        public extern int PrintZReportInBuffer();


        public extern int PrintZReportFromBuffer();


        public extern int ClearPrintBuffer();


        public extern int JournalClear();


        public extern int JournalGetRow();


        public extern int JournalInit();


        public extern int ReadPrintBufferLine();


        public extern int ReadPrintBufferLineNumber();


        public extern int FindDevice();


        public extern int LoadParams();


        public extern int FinishDocument();


        public extern int PrintTrailer();


        public extern int WaitForCheckClose();


        public extern int GetSummFactor();


        public extern int GetQuantityFactor();


        public extern int ReadDeviceMetrics();


        public extern int ReadEcrStatus();


        public extern int SaveState();


        public extern int RestoreState();


        public extern string GetPortNames();


        public extern int LoadImage();


        public extern int OpenNonfiscalDocument();


        public extern int CloseNonFiscalDocument();


        public extern int PrintAttribute();


        public extern int ReadModelParamValue();


        public extern int LoadCashControlParams();


        public extern int GetCashAcceptorStatus();


        public extern int GetCashAcceptorRegisters();


        public extern int CashAcceptorReport();


        public extern int ReadBanknoteCount();


        public extern int PrintOperationalTaxReport();


        public extern int WaitConnection();


        public extern int ReadModelParamDescription();


        public extern int PrintBarcodeUsingPrinter();


        public extern int CloseCheckWithKPK();


        public extern int ReadEKLZActivizationParams();


        public extern int GetShortReportInSessionRange();


        public extern int GetShortReportInDatesRange();


        public extern int ClearResult();


        public extern int ReadLastReceipt();


        public extern int ReadLastReceiptLine();


        public extern int ReadLastReceiptMac();


        public extern int MasterPayClearBuffer();


        public extern int MasterPayAddTextBlock();


        public extern int MasterPayCreateMac();


        public extern int BeginDocument();


        public extern int EndDocument();


        public extern int LoadBlockData();


        public extern int Print2DBarcode();


        public extern int LoadAndPrint2DBarcode();


        public extern int ExcisableOperation();


        public extern int ReadReportBufferLine();


        public extern int ReadParams();


        public extern int GetEKLZCode3Report();


        public extern int ReadModemParameter();


        public extern int WriteModemParameter();


        public extern int GetCashRegEx();


        public extern int GetWareBaseCashRegs();


        public extern int PrintCashierReport();


        public extern int PrintHourlyReport();


        public extern int PrintWareReport();


        public extern int UpdateWare();


        public extern int ReadWare();


        public extern int RemoveWare();


        public extern int CheckFM();


        public extern int ReadErrorDescription();


        public extern int ReadModelParam();


        public extern int InitEEPROM();


        public extern int CheckConnection();


        public extern int ChangeProtocol();


        public extern int GetECRParams();


        public extern int JournalOperation();


        public extern int GetMFPCode3Status();


        public extern int MFPPrepareActivization();


        public extern int MFPGetPermitActivizationCode();


        public extern int MFPActivization();


        public extern int MFPGetPrepareActivizationResult();


        public extern int MFPGetCustomerCode();


        public extern int MFPCloseArchive();


        public extern int MFPSetCustomerCode();


        public extern int MFPSetPermitActivizationCode();


        public extern int CloseCheckEx();


        public extern int ClearReportBuffer();


        public extern int ShowAdditionalParams();


        public extern int GetCloudCashdeskParams();


        public extern int DrawScale();


        public extern int PrintGraphics512();


        public extern int LoadGraphics512();


        public extern int FNGetStatus();


        public extern int FNGetSerial();


        public extern int FNGetExpirationTime();


        public extern int FNGetVersion();


        public extern int FNBeginFiscalization();


        public extern int FNFiscalization();


        public extern int FNResetState();


        public extern int FNCancelDocument();


        public extern int FNGetFiscalizationResult();


        public extern int FNFindDocument();


        public extern int FNOpenSession();


        public extern int FNSendTLV();


        public extern int FNDiscountOperation();


        public extern int FNStorno();


        public extern int FNBeginRegistrationReport();


        public extern int FNBuildRegistrationReport();


        public extern int FNBeginCorrectionReceipt();


        public extern int FNBuildCorrectionReceipt();


        public extern int FNBeginCalculationStateReport();


        public extern int FNBuildCalculationStateReport();


        public extern int FNCloseSession();


        public extern int FNGetInfoExchangeStatus();


        public extern int FNRequestFiscalDocumentTLV();


        public extern int FNReadFiscalDocumentTLV();


        public extern int FNGetOFDTicketByDocNumber();


        public extern int FNBeginCloseFiscalMode();


        public extern int FNCloseFiscalMode();


        public extern int FNGetUnconfirmedDocCount();


        public extern int FNGetCurrentSessionParams();


        public extern int FNBeginOpenSession();


        public extern int FNBeginCloseSession();


        public extern int FNBuildReregistrationReport();


        public extern int FNDiscountTaxOperation();


        public extern int FNCloseCheckEx();


        public extern int FNSendCustomerEmail();


        public extern int Annulment();


        public extern int FNDiscountChargeRN();


        public extern int ImportTables();


        public extern int ExportTables();

        public string BarCode;

        public bool BatteryCondition;

        public double BatteryVoltage;

        public int BaudRate;

        public decimal Change;

        public decimal CheckResult;

        public int CheckType;

        public int ComNumber;

        public decimal ContentsOfCashRegister;

        public int ContentsOfOperationRegister;

        public int CurrentDozeInMilliliters;

        public decimal CurrentDozeInMoney;

        public bool CutType;

        public string DataBlock;

        public int DataBlockNumber;

        public DateTime Date;

        public int Department;

        public int DeviceCode;

        public string DeviceCodeDescription;

        public double DiscountOnCheck;

        public string DocumentName;

        public int DocumentNumber;

        public int DozeInMilliliters;

        public decimal DozeInMoney;

        public int DrawerNumber;

        public int ECRAdvancedMode;

        public string ECRAdvancedModeDescription;

        public int ECRBuild;

        public int ECRFlags;

        public string ECRInput;

        public int ECRMode;

        public int ECRMode8Status;

        public string ECRModeDescription;

        public string ECROutput;

        public DateTime ECRSoftDate;

        public string ECRSoftVersion;

        public bool EKLZIsPresent;

        public int EmergencyStopCode;

        public string EmergencyStopCodeDescription;

        public string FieldName;

        public int FieldNumber;

        public int FieldSize;

        public bool FieldType;

        public int FirstLineNumber;

        public DateTime FirstSessionDate;

        public int FirstSessionNumber;

        public bool FM1IsPresent;

        public bool FM2IsPresent;

        public int FMBuild;

        public int FMFlags;

        public bool FMOverflow;

        public DateTime FMSoftDate;

        public string FMSoftVersion;

        public int FreeRecordInFM;

        public int FreeRegistration;

        public string INN;

        public bool IsCheckClosed;

        public bool IsCheckMadeOut;

        public bool IsDrawerOpen;

        public bool JournalRibbonIsPresent;

        public bool JournalRibbonLever;

        public bool JournalRibbonOpticalSensor;

        public int KPKNumber;

        public int LastLineNumber;

        public DateTime LastSessionDate;

        public int LastSessionNumber;

        public string License;

        public bool LicenseIsPresent;

        public bool LidPositionSensor;

        public string LineData;

        public int LineNumber;

        public int LogicalNumber;

        public int MAXValueOfField;

        public int MINValueOfField;

        public bool Motor;

        public string NameCashReg;

        public string NameOperationReg;

        public int PasswordTI;
                    
        public int OpenDocumentNumber;

        public int OperatorNumber;

        public int Password;

        public bool Pistol;

        public bool PointPosition;

        public int PortNumber;

        public decimal Price;

        public double Quantity;

        public int QuantityOfOperations;

        public bool ReceiptRibbonIsPresent;

        public bool ReceiptRibbonLever;

        public bool ReceiptRibbonOpticalSensor;

        public int RegisterNumber;

        public int RegistrationNumber;

        public bool ReportType;

        public int ResultCode;

        public string ResultCodeDescription;

        public int RKNumber;

        public string RNM;

        public bool RoughValve;

        public int RowNumber;

        public int RunningPeriod;

        public string SerialNumber;

        public int SessionNumber;

        public bool SlipDocumentIsMoving;

        public bool SlipDocumentIsPresent;

        public int SlowingInMilliliters;

        public bool SlowingValve;

        public int StatusRK;

        public string StatusRKDescription;

        public string StringForPrinting;

        public int StringQuantity;

        public decimal Summ1;

        public decimal Summ2;

        public decimal Summ3;

        public decimal Summ4;

        public string TableName;

        public int TableNumber;

        public int Tax1;

        public int Tax2;

        public int Tax3;

        public int Tax4;

        public DateTime Time;

        public int Timeout;

        public string TimeStr;

        public string TransferBytes;

        public int TRKNumber;

        public bool TypeOfLastEntryFM;

        public bool TypeOfSumOfEntriesFM;

        public int UCodePage;

        public string UDescription;

        public int UMajorProtocolVersion;

        public int UMajorType;

        public int UMinorProtocolVersion;

        public int UMinorType;

        public int UModel;

        public bool UseJournalRibbon;

        public bool UseReceiptRibbon;

        public bool UseSlipDocument;

        public int ValueOfFieldInteger;

        public string ValueOfFieldString;

        public int FontType;

        public int LDBaudrate;

        public int LDComNumber;

        public int LDCount;

        public int LDIndex;

        public string LDName;

        public int LDNumber;

        public int WaitPrintingTime;

        public bool IsPrinterLeftSensorFailure;

        public bool IsPrinterRightSensorFailure;

        public string EKLZNumber;

        public decimal LastKPKDocumentResult;

        public DateTime LastKPKDate;

        public DateTime LastKPKTime;

        public int LastKPKNumber;

        public int EKLZFlags;

        public int TestNumber;

        public string EKLZVersion;

        public string EKLZData;

        public int EKLZResultCode;

        public int FMResultCode;

        public double PowerSourceVoltage;

        public bool IsEKLZOverflow;

        public int CopyType;

        public int NumberOfCopies;

        public int CopyOffset1;

        public int CopyOffset2;

        public int CopyOffset3;

        public int CopyOffset4;

        public int CopyOffset5;

        public int ClicheFont;

        public int HeaderFont;

        public int EKLZFont;

        public int ClicheStringNumber;

        public int HeaderStringNumber;

        public int EKLZStringNumber;

        public int FMStringNumber;

        public int ClicheOffset;

        public int HeaderOffset;

        public int EKLZOffset;

        public int KPKOffset;

        public int FMOffset;

        public int OperationBlockFirstString;

        public int QuantityFormat;

        public int StringQuantityInOperation;

        public int TextStringNumber;

        public int QuantityStringNumber;

        public int SummStringNumber;

        public int DepartmentStringNumber;

        public int TextFont;

        public int QuantityFont;

        public int MultiplicationFont;

        public int PriceFont;

        public int SummFont;

        public int DepartmentFont;

        public int TextSymbolNumber;

        public int QuantitySymbolNumber;

        public int PriceSymbolNumber;

        public int SummSymbolNumber;

        public int DepartmentSymbolNumber;

        public int TextOffset;

        public int QuantityOffset;

        public int SummOffset;

        public int DepartmentOffset;

        public bool IsClearUnfiscalInfo;

        public int InfoType;

        public int StringNumber;

        public int EjectDirection;

        public int OperationNameStringNumber;

        public int OperationNameFont;

        public int OperationNameOffset;

        public int TotalStringNumber;

        public int Summ1StringNumber;

        public int Summ2StringNumber;

        public int Summ3StringNumber;

        public int Summ4StringNumber;

        public int ChangeStringNumber;

        public int Tax1TurnOverStringNumber;

        public int Tax2TurnOverStringNumber;

        public int Tax3TurnOverStringNumber;

        public int Tax4TurnOverStringNumber;

        public int Tax1SumStringNumber;

        public int Tax2SumStringNumber;

        public int Tax3SumStringNumber;

        public int Tax4SumStringNumber;

        public int SubTotalStringNumber;

        public int DiscountOnCheckStringNumber;

        public int TotalFont;

        public int TotalSumFont;

        public int Summ1Font;

        public int Summ1NameFont;

        public int Summ2NameFont;

        public int Summ3NameFont;

        public int Summ4NameFont;

        public int Summ2Font;

        public int Summ3Font;

        public int Summ4Font;

        public int ChangeFont;

        public int ChangeSumFont;

        public int Tax1NameFont;

        public int Tax2NameFont;

        public int Tax3NameFont;

        public int Tax4NameFont;

        public int Tax1TurnOverFont;

        public int Tax2TurnOverFont;

        public int Tax3TurnOverFont;

        public int Tax4TurnOverFont;

        public int Tax1RateFont;

        public int Tax2RateFont;

        public int Tax3RateFont;

        public int Tax4RateFont;

        public int Tax1SumFont;

        public int Tax2SumFont;

        public int Tax3SumFont;

        public int Tax4SumFont;

        public int SubTotalFont;

        public int SubTotalSumFont;

        public int DiscountOnCheckFont;

        public int DiscountOnCheckSumFont;

        public int TotalSymbolNumber;

        public int Summ1SymbolNumber;

        public int Summ2SymbolNumber;

        public int Summ3SymbolNumber;

        public int Summ4SymbolNumber;

        public int ChangeSymbolNumber;

        public int Tax1NameSymbolNumber;

        public int Tax1TurnOverSymbolNumber;

        public int Tax1RateSymbolNumber;

        public int Tax1SumSymbolNumber;

        public int Tax2NameSymbolNumber;

        public int Tax2TurnOverSymbolNumber;

        public int Tax2RateSymbolNumber;

        public int Tax2SumSymbolNumber;

        public int Tax3NameSymbolNumber;

        public int Tax3TurnOverSymbolNumber;

        public int Tax3RateSymbolNumber;

        public int Tax3SumSymbolNumber;

        public int Tax4NameSymbolNumber;

        public int Tax4TurnOverSymbolNumber;

        public int Tax4RateSymbolNumber;

        public int Tax4SumSymbolNumber;

        public int SubTotalSymbolNumber;

        public int DiscountOnCheckSymbolNumber;

        public int DiscountOnCheckSumSymbolNumber;

        public int TotalOffset;

        public int Summ1Offset;

        public int TotalSumOffset;

        public int Summ1NameOffset;

        public int Summ2Offset;

        public int Summ2NameOffset;

        public int Summ3Offset;

        public int Summ3NameOffset;

        public int Summ4Offset;

        public int Summ4NameOffset;

        public int ChangeOffset;

        public int ChangeSumOffset;

        public int Tax1NameOffset;

        public int Tax1TurnOverOffset;

        public int Tax1RateOffset;

        public int Tax1SumOffset;

        public int Tax2NameOffset;

        public int Tax2TurnOverOffset;

        public int Tax2RateOffset;

        public int Tax2SumOffset;

        public int Tax3NameOffset;

        public int Tax3TurnOverOffset;

        public int Tax3RateOffset;

        public int Tax3SumOffset;

        public int Tax4NameOffset;

        public int Tax4TurnOverOffset;

        public int Tax4RateOffset;

        public int Tax4SumOffset;

        public int SubTotalOffset;

        public int SubTotalSumOffset;

        public int SlipDocumentWidth;

        public int SlipDocumentLength;

        public int PrintingAlignment;

        public string SlipStringIntervals;

        public int SlipEqualStringIntervals;

        public int KPKFont;

        public int DiscountOnCheckOffset;

        public int DiscountOnCheckSumOffset;

        public bool QuantityPointPosition;

        public uint FileVersionMS;

        public uint FileVersionLS;

        public bool IsBatteryLow;

        public bool IsLastFMRecordCorrupted;

        public bool IsFMSessionOpen;

        public bool IsFM24HoursOver;

        public int ECRModeStatus;

        public int PrinterStatus;

        public string ServerVersion;

        public string LDComputerName;

        public int LDTimeout;

        public string ComputerName;

        public bool ServerConnected;

        public bool PortLocked;

        public int PrintWidth;

        public int CharWidth;

        public int CharHeight;

        public int FontCount;

        public bool LogOn;

        public bool CPLog;

        public string CashControlHost;

        public string CashControlPort;

        public bool CashControlEnabled;

        public bool CashControlUseTCP;

        public int CashControlPassword;

        public int ConnectionType;

        public int LDConnectionType;

        public int TCPPort;

        public int LDTCPPort;

        public string IPAddress;

        public string LDIPAddress;

        public bool UseIPAddress;

        public bool LDUseIPAddress;

        public string CPLogFile;

        public string ComLogFile;

        public string LineData2;

        public int SysAdminPassword;

        public bool RecoverError165;

        public int MaxRecoverCount;

        public int OperationCode;

        public int AccType;

        public int Address;

        public int WrittenByte;

        public int ReadByte;

        public string TransferByte;

        public int OperationType;

        public bool PresenterIn;

        public bool PresenterOut;

        public bool ComLogOnlyErrors;

        public int SCPassword;

        public string LastKPKDateStr;

        public string LastKPKTimeStr;

        public string MethodName;

        public string PropertyName;

        public int LockTimeout;

        public int SlipStringInterval;

        public int IBMStatusByte1;

        public int IBMStatusByte2;

        public int IBMStatusByte3;

        public int IBMStatusByte4;

        public int IBMStatusByte5;

        public int IBMStatusByte6;

        public int IBMStatusByte7;

        public int IBMStatusByte8;

        public int IBMFlags;

        public int IBMDocumentNumber;

        public int IBMLastSaleReceiptNumber;

        public int IBMLastBuyReceiptNumber;

        public int IBMLastReturnSaleReceiptNumber;

        public int IBMLastReturnBuyReceiptNumber;

        public int IBMSessionDay;

        public int IBMSessionMonth;

        public int IBMSessionYear;

        public int IBMSessionHour;

        public int IBMSessionMin;

        public int IBMSessionSec;

        public DateTime IBMSessionDateTime;

        public string EscapeIP;

        public int EscapePort;

        public string LDEscapeIP;

        public int LDEscapePort;

        public int EscapeTimeout;

        public int LDEscapeTimeout;

        public int CommandTimeout;

        public bool UseCommandTimeout;

        public int CommandCount;

        public int CommandIndex;

        public string CommandName;

        public int CommandDefTimeout;

        public int CommandCode;

        public int TimeoutsUsing;

        public int IntervalNumber;

        public int IntervalValue;

        public bool MobilePayEnabled;

        public int ParamsPageIndex;

        public int ParentWnd;

        public int PayDepartment;

        public int RealPayDepartment;

        public bool SaleError;

        public int ReceiptOutputType;

        public bool CardPayEnabled;

        public int CardPayType;

        public bool ccUseTextAsWareName;

        public int ccWareNameLineNumber;

        public int ccHeaderLineCount;

        public bool LogCommands;

        public bool LogMethods;

        public int BarcodeType;

        public string BarcodeTypes;

        public string BarcodeAlignments;

        public int BarWidth;

        public bool CapGetShortECRStatus;

        public int WaitForPrintingDelay;

        public bool LineSwapBytes;
                    
        public bool JournalEnabled;
                    
        public string JournalRow;

        public int JournalRowCount;

        public int JournalRowNumber;
                    
        public string JournalText;

        public int LogFileMaxSize;

        public int BufferFormat;

        public int Pr;

        public int BufferLineNumber;
                    
        public int NakCount;

        public int MaxCommandSendCount;

        public int MaxAnswerReadCount;

        public int MaxENQSendCount;
                    
        public string LineDataHex;

        public int SerialNumberAsInteger;
                    
        public int INNAsInteger;
        public DateTime ECRDate;
        public DateTime ECRTime;
                    
        public bool HasCashControlLicense;
                    
        public int BufferingType;
                    
        public int CommandRetryCount;
                    
        public string FileName;
                    
        public bool CenterImage;
                    
        public bool ShowProgress;
                    
        public int AttributeNumber;
                    
        public string AttributeValue;
                    
        public int ModelID;
                    object ModelParamValue;
                    
        public int ModelParamNumber;
                    
        public bool Connected;
                    
        public int PrintBarcodeText;
                    
        public int EnteredTaxPassword;
                    
        public int Poll1;
                    
        public int Poll2;
                    
        public int CashAcceptorPollingMode;
                    
        public int BanknoteType;
                    
        public int BanknoteCount;
                    
        public bool FeedAfterCut;
                    
        public int FeedLineCount;
                    
        public int LDSysAdminPassword;
                    
        public bool CapOpenCheck;
                    
        public string PollDescription;
                    
        public int ConnectionTimeout;
                    
        public string ModelParamDescription;
        public uint DriverMajorVersion;
        public uint DriverMinorVersion;
        public uint DriverRelease;
        public uint DriverBuild;
                    
        public string DriverVersion;
                    
        public int HRIPosition;
                    
        public string KPKStr;
                    
        public int TextBlockNumber;
                    
        public string TextBlock;
                    
        public string CashControlProtocols;
                    
        public string PosControlReceiptSeparator;
                    
        public int BlockType;
                    
        public int BlockNumber;
                    
        public string BlockDataHex;
                    
        public int BarcodeDataLength;
                    
        public int BarcodeParameter1;
                    
        public int BarcodeParameter2;
                    
        public int BarcodeParameter3;
                    
        public int BarcodeParameter4;
                    
        public int BarcodeParameter5;
                    
        public int BarcodeStartBlockNumber;
                    
        public int ExciseCode;
                    
        public int LogMaxFileSize;
                    
        public int LogMaxFileCount;
                    
        public int SaveSettingsType;
                    
        public bool PrintJournalBeforeZReport;
                    
        public int TransmitStatus;
                    
        public int TransmitQueueSize;
                    
        public int TransmitSessionNumber;
                    
        public int TransmitDocumentNumber;
                    
        public int ParameterNumber;
                    
        public string ParameterValue;
                    
        public bool TranslationEnabled;
                    
        public int ModelIndex;
                    
        public string ModelNames;
                    
        public int ModelsCount;
                    
        public int FMFlagsEx;
                    
        public int FMMode;
                    
        public bool IsASPDMode;
                    
        public bool IsCorruptedFMRecords;
                    
        public bool IsCorruptedFiscalizationInfo;
                    
        public bool CarryStrings;
                    
        public bool DelayedPrint;
                    
        public decimal RegSaleRec;
                    
        public decimal RegBuyRec;
                    
        public decimal RegSaleReturnRec;
                    
        public decimal RegBuyReturnRec;
                    
        public decimal RegSaleSession;
                    
        public decimal RegBuySession;
                    
        public decimal RegSaleReturnSession;
                    
        public decimal RegBuyReturnSession;
                    
        public int WareCode;
                    
        public int RecordCount;
                    
        public int CheckingType;
                    
        public int ErrorCode;
                    
        public bool UseWareCode;
                    
        public bool RequestErrorDescription;
                    
        public string ErrorDescription;
                    
        public bool AdjustRITimeout;
                    
        public string UCodePageText;
                    
        public bool ReconnectPort;
                    
        public bool DoNotSendENQ;
                    
        public int SwapBytesMode;
                    
        public int ModelParamIndex;
                    
        public int ModelParamCount;
                    
        public bool CheckFMConnection;
                    
        public bool CheckEJConnection;
                    
        public string BarcodeHex;
                    
        public int ProtocolType;
                    
        public int LDProtocolType;
                    
        public int LastPrintResult;
                    
        public bool UseSlipCheck;
                    
        public int TypeOfLastEntryFMEx;
                    
        public bool AutoSensorValues;
                    
        public int SearchTimeout;
                    
        public bool AutoStartSearch;
                    
        public int TCPConnectionTimeout;
                    
        public decimal Summ5;
                    
        public decimal Summ6;
                    
        public decimal Summ7;
                    
        public decimal Summ8;
                    
        public decimal Summ9;
                    
        public decimal Summ10;
                    
        public decimal Summ11;
                    
        public decimal Summ12;
                    
        public decimal Summ13;
                    
        public decimal Summ14;
                    
        public decimal Summ15;
                    
        public decimal Summ16;
                    
        public int CustomerCode;
                    
        public int PermitActivizationCode;
                    
        public string NameCashRegEx;
                    
        public int ActivizationStatus;
                    
        public int MFPStatus;
                    
        public string MFPNumber;
                    
        public int KPKValue;
                    
        public int ActivizationControlByte;
                    
        public int PrepareActivizationRemainCount;
                    
        public int AnswerCode;
                    
        public int RequestType;
                    
        public int ReadTimeout;
                    
        public int LastFMRecordType;
                    
        public bool IsBlockedByWrongTaxPassword;
                    
        public bool CloudCashdeskEnabled;
                    
        public string ECRID;
                    
        public string KSAInfo;
                    
        public int VertScale;
                    
        public int HorizScale;
                    
        public int BarcodeFirstLine;
                    
        public int SKNOStatus;
                    
        public int SKNOError;
                    
        public string SKNOIdentifier;
                    
        public int LineLength;
                    
        public int GraphBufferType;
                    
        public int FNLifeState;
                    
        public int FNCurrentDocument;
                    
        public int FNDocumentData;
                    
        public int FNSessionState;
                    
        public int FNWarningFlags;
                    
        public string FNSoftVersion;
                    
        public int SyncTimeout;
                    
        public int FNSoftType;
                    
        public int FiscalSign;
                    
        public string KKTRegistrationNumber;
                    
        public int TaxType;
                    
        public int WorkMode;
                    
        public int DocumentType;
                    
        public bool OFDTicketReceived;
                    
        public string DocumentData;
                    
        public string TLVData;
                    
        public string OFDServer;
                    
        public int OFDPort;
                    
        public int OFDPollPeriod;
                    
        public bool OFDEnabled;
                    
        public int DocumentCount;
                    
        public int ReceiptNumber;
                    
        public int MessageState;
                    
        public int InfoExchangeStatus;
                    
        public int MessageCount;
                    
        public int ReportTypeInt;
                    
        public int DataLength;
                    
        public decimal DiscountValue;
                    
        public decimal ChargeValue;
                    
        public decimal TaxValue;
                    
        public int RegistrationReasonCode;
                    
        public string DiscountName;
                    
        public string CustomerEmail;
        public DateTime Date2;
        public DateTime Time2;
                    
        public string FiscalSignOFD;

        public bool AutoOpenSession;

        public TBarcodeAlignment BarcodeAlignment;
    }
}