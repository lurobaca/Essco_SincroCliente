using System.Runtime.InteropServices;
using Essco.Application.Configuration;
using Essco.Application.Customers;
using Essco.Application.Treasury;
using Microsoft.Extensions.Options;

namespace Essco.SapBridge.Worker;

public sealed class ComSapIncomingReceiptGateway(IOptions<EsscoOptions> options, ILogger<ComSapIncomingReceiptGateway> logger) : ISapIncomingReceiptGateway
{
    public ValueTask<SapProcessingResult> ExecuteAsync(string operation, IncomingReceiptSapPayload receipt, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (!options.Value.Sap.Enabled) return ValueTask.FromResult(new SapProcessingResult(false,null,"La conexión SAP no está habilitada.",false));
        var completion=new TaskCompletionSource<SapProcessingResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        var thread=new Thread(()=>{try{completion.TrySetResult(Execute(operation,receipt));}catch(COMException ex){logger.LogWarning("Error COM SAP {Code} actualizando recibo {Receipt}",ex.ErrorCode,receipt.DocNumber);completion.TrySetResult(new(false,null,$"Error COM SAP ({ex.ErrorCode}).",true));}catch(Exception ex){logger.LogError(ex,"Error actualizando recibo {Receipt}",receipt.DocNumber);completion.TrySetResult(new(false,null,"Error interno del adaptador SAP.",true));}}){IsBackground=true,Name="Essco SAP DI API Receipt"};
        thread.SetApartmentState(ApartmentState.STA);thread.Start();return new(completion.Task);
    }
    private SapProcessingResult Execute(string operation,IncomingReceiptSapPayload receipt)
    {
        dynamic? company=null;dynamic? payment=null;
        try
        {
            var type=Type.GetTypeFromProgID("SAPbobsCOM.Company")??throw new COMException("SAP Business One DI API no está registrada."); company=Activator.CreateInstance(type)??throw new COMException("No fue posible crear SAPbobsCOM.Company.");
            var c=options.Value.Sap;company.Server=c.Server;company.CompanyDB=c.CompanyDatabase;company.UserName=c.UserName;company.Password=c.Password;company.DbUserName=c.DatabaseUserName;company.DbPassword=c.DatabasePassword;company.LicenseServer=c.LicenseServer;company.DbServerType=c.DatabaseServerType;company.UseTrusted=false;
            var connected=(int)company.Connect();if(connected!=0)return Failure(company,connected,true);
            payment=company.GetBusinessObject(24); // BoObjectTypes.oIncomingPayments
            if(!(bool)payment.GetByKey(receipt.DocEntry))return new(false,null,"El recibo no existe en SAP.",false);
            SetUserField(payment,"U_BP_COBRADOR",operation==IncomingReceiptSapOperations.Unlink?"":receipt.CollectorCode);
            SetUserField(payment,"U_NumLiquidacion",operation==IncomingReceiptSapOperations.Unlink?"":receipt.LiquidationNumber);
            var updated=(int)payment.Update();return updated==0?new(true,receipt.DocNumber.ToString(System.Globalization.CultureInfo.InvariantCulture),null,false):Failure(company,updated,false);
        }
        finally{Release(payment);try{if(company is not null&&(bool)company.Connected)company.Disconnect();}catch(COMException){}Release(company);}
    }
    private static void SetUserField(dynamic target,string name,object value)=>target.UserFields.Fields.Item(name).Value=value;
    private static SapProcessingResult Failure(dynamic company,int code,bool retryable){string message="";try{company.GetLastError(out code,out message);}catch(COMException){}return new(false,null,$"SAP rechazó la operación ({code}): {message}",retryable);}
    private static void Release(object? value){if(value is not null&&Marshal.IsComObject(value))Marshal.FinalReleaseComObject(value);}
}
