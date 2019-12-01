using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            var copyMachine = new CopyMachine();

            copyMachine.DepositCoins(1);
            copyMachine.SelectStorageMedia(StorageMedia.UsbFlashDrive);
            copyMachine.SelectDocument(1);
            copyMachine.Print();
            copyMachine.SelectDocument(3);
            copyMachine.Print();
            copyMachine.TakeChange();
            copyMachine.Complete();
        }
    }
}