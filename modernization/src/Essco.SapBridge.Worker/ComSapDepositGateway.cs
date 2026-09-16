using System.Runtime.InteropServices;
using Essco.Application.Configuration;
using Essco.Application.Customers;
using Essco.Application.Treasury;
using Microsoft.Extensions.Options;

namespace Essco.SapBridge.Worker;

public sealed class ComSapDepositGateway(IOptions<EsscoOptions> options, ILogger<ComSapDepositGateway> logger) : ISapDepositGateway
{
    public ValueTask<SapProcessingResult> CreateAsync(DepositSapPayload deposit, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (!options.Value.Sap.Enabled) return ValueTask.FromResult(new SapProcessingResult(false,null,"La conexión SAP no está habilitada.",false));
        var completion=new TaskCompletionSource<SapProcessingResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        var thread=new Thread(()=>{try{completion.TrySetResult(Create(deposit));}catch(COMException ex){logger.LogWarning("Error COM SAP {Code} creando depósito {Deposit}",ex.ErrorCode,deposit.Consecutive);completion.TrySetResult(new(false,null,$"Error COM SAP ({ex.ErrorCode}).",true));}catch(Exception ex){logger.LogError(ex,"Error creando depósito {Deposit}",deposit.Consecutive);completion.TrySetResult(new(false,null,"Error interno del adaptador SAP.",true));}}){IsBackground=true,Name="Essco SAP DI API Deposit"};
        thread.SetApartmentState(ApartmentState.STA);thread.Start();return new(completion.Task);
    }
    private SapProcessingResult Create(DepositSapPayload deposit)
    {
        dynamic? company=null;object? companyService=null;object? depositService=null;dynamic? sapDeposit=null;object? result=null;
        try
        {
            var companyType=Type.GetTypeFromProgID("SAPbobsCOM.Company")??throw new COMException("SAP Business One DI API no está registrada.");company=Activator.CreateInstance(companyType)??throw new COMException("No fue posible crear SAPbobsCOM.Company.");
            var c=options.Value.Sap;company.Server=c.Server;company.CompanyDB=c.CompanyDatabase;company.UserName=c.UserName;company.Password=c.Password;company.DbUserName=c.DatabaseUserName;company.DbPassword=c.DatabasePassword;company.LicenseServer=c.LicenseServer;company.DbServerType=c.DatabaseServerType;company.UseTrusted=false;
            var connected=(int)company.Connect();if(connected!=0)return Failure(company,connected,true);
            companyService=company.GetCompanyService();
            var serviceType=Type.GetType("SAPbobsCOM.ServiceTypes, SAPbobsCOM")??throw new COMException("ServiceTypes no está disponible.");var depositsService=Enum.Parse(serviceType,"DepositsService");
            depositService=((dynamic)companyService).GetBusinessService(depositsService);
            var interfaceType=Type.GetType("SAPbobsCOM.DepositsServiceDataInterfaces, SAPbobsCOM")??throw new COMException("DepositsServiceDataInterfaces no está disponible.");var depositInterface=Enum.Parse(interfaceType,"dsDeposit");
            sapDeposit=((dynamic)depositService).GetDataInterface(depositInterface);
            sapDeposit.DepositType=0; // BoDepositTypeEnum.dtCash
            sapDeposit.DepositCurrency=c.DepositCurrency;sapDeposit.AllocationAccount=c.DepositAllocationAccount;sapDeposit.DepositAccount=deposit.BankAccount;sapDeposit.TotalLC=(double)deposit.Amount;
            sapDeposit.JournalRemarks=$"DEPOSITO EN LIQUIDACION DE AGENTE {deposit.LiquidationNumber}";sapDeposit.DepositDate=deposit.AccountingDate.ToDateTime(TimeOnly.MinValue);sapDeposit.BankReference=deposit.Number;
            result=((dynamic)depositService).AddDeposit(sapDeposit);var externalId=Convert.ToString(((dynamic)result).DepositNumber)??deposit.Number;return new(true,externalId,null,false);
        }
        finally{Release(result);Release(sapDeposit);Release(depositService);Release(companyService);try{if(company is not null&&(bool)company.Connected)company.Disconnect();}catch(COMException){}Release(company);}
    }
    private static SapProcessingResult Failure(dynamic company,int code,bool retryable){string message="";try{company.GetLastError(out code,out message);}catch(COMException){}return new(false,null,$"SAP rechazó la operación ({code}): {message}",retryable);}
    private static void Release(object? value){if(value is not null&&Marshal.IsComObject(value))Marshal.FinalReleaseComObject(value);}
}
