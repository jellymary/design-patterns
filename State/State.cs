using System;

namespace State
{
    // Context
    public class CopyMachine
    {
        public IState State { get; set; }
        public int Coins { get; set; }
        public StorageMedia? StorageMedia { get; set; }

        public CopyMachine()
        {
            Coins = 0;
            StorageMedia = null;
            State = new InitState();
        }

        public void DepositCoins(int coins) => State.DepositCoins(this, coins);

        public void SelectStorageMedia(StorageMedia storageMedia) => State.SelectStorageMedia(this, storageMedia);

        public void SelectDocument(int docNumber) => State.SelectDocument(this, docNumber);

        public void Print() => State.Print(this);

        public int TakeChange() => State.TakeChange(this);

        public void Complete() => State.Complete(this);
    }

    public interface IState
    {
        void DepositCoins(CopyMachine copyMachine, int coins);
        void SelectStorageMedia(CopyMachine copyMachine, StorageMedia storageMedia);
        void SelectDocument(CopyMachine copyMachine, int docNumber);
        void Print(CopyMachine copyMachine);
        int TakeChange(CopyMachine copyMachine);
        void Complete(CopyMachine copyMachine);
    }

    public abstract class StateBase : IState
    {
        public virtual void DepositCoins(CopyMachine copyMachine, int coins)
        {
            throw new Exception("It's impossible to deposit coins now");
        }
        public virtual void SelectStorageMedia(CopyMachine copyMachine, StorageMedia storageMedia)
        {
            throw new Exception("It's impossible to select storage media now");
        } 

        public virtual void SelectDocument(CopyMachine copyMachine, int docNumber)
        {
            throw new Exception("It's impossible to select document now");
        } 
        public virtual void Print(CopyMachine copyMachine)
        {
            throw new Exception("It's impossible to print documents now");
        }

        public virtual int TakeChange(CopyMachine copyMachine)
        {
            throw new Exception("It's impossible to take change now");
        }

        public virtual void Complete(CopyMachine copyMachine)
        {
            Console.WriteLine("Thank you for using the copy machine :)");
            copyMachine.State = new InitState();
        }
    }

    public class InitState : StateBase
    {
        public override void DepositCoins(CopyMachine copyMachine, int coins)
        {
            copyMachine.Coins += coins;
            Console.WriteLine($"{coins} coins were deposited");
            copyMachine.State = new SelectStorageMediaState();
        }

        public override void SelectStorageMedia(CopyMachine copyMachine, StorageMedia storageMedia)
        {
            throw new Exception("You haven't deposited any coins yet");
        }
    }

    public class SelectStorageMediaState : StateBase
    {
        public override void DepositCoins(CopyMachine copyMachine, int coins)
        {
            Console.WriteLine($"{coins} coins were deposited");
            copyMachine.Coins += coins;
        }

        public override void SelectStorageMedia(CopyMachine copyMachine, StorageMedia storageMedia)
        {
            copyMachine.StorageMedia = storageMedia;
            Console.WriteLine($"{storageMedia} is selected as the storage media");
            copyMachine.State = new SelectDocumentState(); 
        }
    }
    
    public class SelectDocumentState : StateBase
    {
        public override void SelectDocument(CopyMachine copyMachine, int docNumber)
        {
            if (copyMachine.Coins > 0)
            {
                Console.WriteLine($"Selected document number {docNumber}");
                copyMachine.State = new PrintState();
            }
            else
            {
                Console.WriteLine("Sorry, deposit is empty for printing documents");
                copyMachine.State = new CompleteState();
            }
        }
    }

    public class PrintState : StateBase
    {
        public override void Print(CopyMachine copyMachine)
        {
            copyMachine.Coins -= 1;
            Console.WriteLine("Print selected documents...");
            copyMachine.State = new TakeChangeState();
        }
    }

    public class TakeChangeState : StateBase
    {
        public override void SelectDocument(CopyMachine copyMachine, int docNumber)
        {
            if (copyMachine.Coins > 0)
            {
                Console.WriteLine($"Selected document number {docNumber}");
                copyMachine.State = new PrintState();
            }
            else
            {
                Console.WriteLine("Sorry, deposit is empty for printing documents");
                copyMachine.State = new CompleteState();
            }
        }
        public override int TakeChange(CopyMachine copyMachine)
        {
            Console.WriteLine($"Take the change of {copyMachine.Coins} coins");
            var change = copyMachine.Coins;
            copyMachine.Coins = 0;
            copyMachine.State = new CompleteState();
            return change;
        }
    }

    public class CompleteState : StateBase
    {
        public override void Print(CopyMachine copyMachine) { }
        public override int TakeChange(CopyMachine copyMachine) => 0;
    }
}