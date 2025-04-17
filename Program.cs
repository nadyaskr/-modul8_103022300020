using System;
using System.Diagnostics.SymbolStore;
using System.Net.Http.Json;
using System.Text.Json;

public class Transfer
{
    public string threshold { get; set; }   
    public string low_fee { get; set; }
    public string high_fee { get; set; }
}

public class Confirmation
{
    public string en { get; set; }
    public string id { get; set; }
}

public class BankTransferConfig
{
    public string lang { get; set; }
    public Transfer transfer { get; set; }
    public string[] method { get; set; }
    public Confirmation confirmation { get; set; }  
    private static string configFilePath = "bank_transfer_config.json";

    public static BankTransferConfig LoadfromFile(string configFilePath)
    {
        var defultConfig = new BankTransferConfig();
        {
            lang = "en";
            transfer = new Transfer()
            {
                threshold = 25000000,
                low_fee = 6500,
                high_fee = 15000
            },
            method = ["RTO(RealTime), SKN, RTGS, BI, BI FAST"],
            confirmation = new Confirmation()
            {
                en = "yes",
                id = "ya"
            }
        };
        return defultConfig;
        string jsonContent = File.ReadAllText(configFilePath);
        var config = JsonSerializer.Deserialize<BankTransferConfig>(jsonContent);

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        {
            WriteIndented = true,
        };
        File.WriteAllText(configFilePath, JsonSerializer.Serialize(config, jsonOption);
    }
}

class program
{
    public static void Main(string[] args)
    {
        BankTransferConfig bankTransferConfig = new BankTransferConfig();   
        if (bankTransferConfig.lang == "en")
        {
            Console.WriteLine($"Please insert the amount of money to transfer: ");
        }
        else
        {
            Console.WriteLine($"Masukkan jumlah uang yang akan di transfer : ");
        }
        int amount = Int32.Parse(Console.ReadLine() ); 

        int transferFree = 0;
        if (amount <= bankTransferConfig.transfer.threshold)
        {
            transferFee = bankTransferConfig.transfer.low_fee;
        }
        else if (amount >= bankTransferConfig.transfer.threshold)
        {
            transferFree = bankTransferConfig.transfer.high_fee;
        }

        if(bankTransferConfig.lang == "en")
        {
            Console.WriteLine($"Transfer fee: {transferFee} ");
            Console.WriteLine($"Total amount: {amount + transferFree}");
        }else if(bankTransferConfig.lang == "id")
        {
            Console.WriteLine($"Biaya transfer: {transferFree} ");
            Console.WriteLine($"Total biaya : {amount + transferFree}");
        }
        if (bankTransferConfig.lang == "en")
        {
            Console.WriteLine($""
        }
    }
}
