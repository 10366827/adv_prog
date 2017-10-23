using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel;

namespace _10366827
{
    //  Implements IBindlist list in order to bind the data to the gridview, and IEnumerable for argument passing
    public class BetDataHandler: System.ComponentModel.IBindingList, IEnumerable<Bet>
    {
        //  Interface
        public int Count => ((ICollection<Bet>)bets).Count;
        public bool IsReadOnly => ((ICollection<Bet>)bets).IsReadOnly;

        public bool AllowNew => ((IBindingList)bets).AllowNew;

        public bool AllowEdit => ((IBindingList)bets).AllowEdit;

        public bool AllowRemove => ((IBindingList)bets).AllowRemove;

        public bool SupportsChangeNotification => ((IBindingList)bets).SupportsChangeNotification;

        public bool SupportsSearching => ((IBindingList)bets).SupportsSearching;

        public bool SupportsSorting => ((IBindingList)bets).SupportsSorting;

        public bool IsSorted => ((IBindingList)bets).IsSorted;

        public PropertyDescriptor SortProperty => ((IBindingList)bets).SortProperty;

        public ListSortDirection SortDirection => ((IBindingList)bets).SortDirection;

        public bool IsFixedSize => ((IBindingList)bets).IsFixedSize;

        public object SyncRoot => ((IBindingList)bets).SyncRoot;

        public bool IsSynchronized => ((IBindingList)bets).IsSynchronized;

        object IList.this[int index] { get => ((IBindingList)bets)[index]; set => ((IBindingList)bets)[index] = value; }
        public Bet this[int index] { get => ((IList<Bet>)bets)[index]; set => ((IList<Bet>)bets)[index] = value; }

        public event ListChangedEventHandler ListChanged;

        //  Data
        private BindingList<Bet> bets;
        private string betsFilePath = null;

        //  Default Constructor, generates default data if file isn't already created, else loads file
        public BetDataHandler()
        {
            string defaultOutputDataDirectory = Path.Combine(Directory.GetCurrentDirectory(), ConfigurationManager.AppSettings["defaultOutputDirectory"]);
            string defaultOutputFileName = ConfigurationManager.AppSettings["defaultOutputFileName"];

            betsFilePath = Path.Combine(defaultOutputDataDirectory, defaultOutputFileName);
            if (!File.Exists(betsFilePath))
            {
                if (!Directory.Exists(defaultOutputDataDirectory))
                    Directory.CreateDirectory(defaultOutputDataDirectory);
                bets = new BindingList<Bet>(BetTestData.GetHotTipsterTestData());
                UpdateBinaryFile();
            }
            else
            {
                bets = DeserializeBetsBinaryFile(betsFilePath);
            }
        }

        //  If want to pass an existing file 
        public BetDataHandler(string existingBinFilePath)
        {
            if (existingBinFilePath == null || existingBinFilePath.Length == 0)
                throw new FileNotFoundException("Filepath passed to BetDataHandler constructor null or empty.");
            else if (!File.Exists(existingBinFilePath))
            {
                throw new FileNotFoundException($"Filepath: '{existingBinFilePath}' does not exist.");
            }
            else if (!existingBinFilePath.ToLower().EndsWith(".bin"))
            {
                throw new FileLoadException($"File {existingBinFilePath} not a binary file. Application requires a binary file.");
            }
                
            betsFilePath = existingBinFilePath;
            bets = DeserializeBetsBinaryFile(betsFilePath);
        }

        //  If changing to a set of given bets
        public BetDataHandler(List<Bet> _bets)
        {
            string defaultOutputDataDirectory = Path.Combine(Directory.GetCurrentDirectory(), ConfigurationManager.AppSettings["defaultOutputDirectory"]);
            string defaultOutputFileName = ConfigurationManager.AppSettings["defaultOutputFileName"];

            betsFilePath = Path.Combine(defaultOutputDataDirectory, defaultOutputFileName);
            if (!File.Exists(betsFilePath))
            {
                if (!Directory.Exists(defaultOutputDataDirectory))
                    Directory.CreateDirectory(defaultOutputDataDirectory);
                bets = new BindingList<Bet>(_bets);
                UpdateBinaryFile();
            }
            else
            {
                bets = new BindingList<Bet>(_bets);
                UpdateBinaryFile();
            }
        }
        
        //  Updates data in the binary file to match List of bets
        private void UpdateBinaryFile()
        {
            using (Stream stream = File.Open(betsFilePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, bets.ToList());
            }
        }

        //  Deserialize the data on the binary file, turning into list of Bet objects
        public BindingList<Bet> DeserializeBetsBinaryFile(string binaryFilepath)
        {
            if (!File.Exists(binaryFilepath))
            {
                throw new FileNotFoundException($"{binaryFilepath} not found.");
            }
            else if (!binaryFilepath.ToLower().EndsWith(".bin"))
            {
                throw new FormatException("File must be a binary(.bin) file.");
            }
            else if(new FileInfo(binaryFilepath).Length == 0)
            {
                //  File empty
                return new BindingList<Bet>();
            }

            using (Stream stream = File.OpenRead(binaryFilepath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return new BindingList<Bet>(
                    (formatter.Deserialize(stream) as List<Bet>) ?? new List<Bet>()
                );
            }
        }

        //  Add a new bet
        public void Add(Bet newBet)
        {
            //if (newBet == null || !Bet.IsValid(newBet))
            //    throw new InvalidBetException("Bet passed to BetDataHandler through 'add' function was " + newBet == null ? "null." : "invalid.");

            bets.Add(newBet);
            UpdateBinaryFile();
        }

        //  Empty the list AND the binary file
        public void Clear()
        {
            ((ICollection<Bet>)bets).Clear();
            UpdateBinaryFile();
        }

        //  Remove a bet from the list AND binary file
        public bool Remove(Bet item)
        {
            bool removed = ((ICollection<Bet>)bets).Remove(item);

            if (removed)
                UpdateBinaryFile();

            return removed;
        }

        //  Sort list by date
        public void SortByDate()
        {
            bets = new BindingList<Bet>(ReportGenerator.GetBetsOrderedByDate(bets).ToList());
        }

        //  Sort list by trackname
        public void SortByTrackName()
        {
            bets = new BindingList<Bet>(ReportGenerator.GetBetsOrderedByTrackName(bets).ToList());
        }

        //  Sort list by bet amount placed
        public void SortByMoney()
        {
            bets = new BindingList<Bet>(ReportGenerator.GetBetsOrdersByMoney(bets).ToList());
        }

        //  Sort from wins to losses
        public void SortByWins()
        {
            bets = new BindingList<Bet>(ReportGenerator.GetBetsOrdersByWinning(bets).ToList());
        }

        public IEnumerator<Bet> GetEnumerator()
        {
            return 
                ((ICollection<Bet>)bets).GetEnumerator();
        }

        public int IndexOf(Bet item)
        {
            return ((IList<Bet>)bets).IndexOf(item);
        }

        public void Insert(int index, Bet item)
        {
            ((IList<Bet>)bets).Insert(index, item);
            UpdateBinaryFile();
        }

        public void RemoveAt(int index)
        {
            ((IList<Bet>)bets).RemoveAt(index);
            UpdateBinaryFile();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<Bet>)bets).GetEnumerator();
        }

        public bool Contains(Bet item)
        {
            return ((IList<Bet>)bets).Contains(item);
        }

        public void CopyTo(Bet[] array, int arrayIndex)
        {
            ((IList<Bet>)bets).CopyTo(array, arrayIndex);
        }

        public object AddNew()
        {
            return ((IBindingList)bets).AddNew();
        }

        public void AddIndex(PropertyDescriptor property)
        {
            ((IBindingList)bets).AddIndex(property);
        }

        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            ((IBindingList)bets).ApplySort(property, direction);
        }

        public int Find(PropertyDescriptor property, object key)
        {
            return ((IBindingList)bets).Find(property, key);
        }

        public void RemoveIndex(PropertyDescriptor property)
        {
            ((IBindingList)bets).RemoveIndex(property);
            UpdateBinaryFile();
        }

        public void RemoveSort()
        {
            ((IBindingList)bets).RemoveSort();
        }

        public int Add(object value)
        {
            return ((IBindingList)bets).Add(value);
        }

        public bool Contains(object value)
        {
            return ((IBindingList)bets).Contains(value);
        }

        public int IndexOf(object value)
        {
            return ((IBindingList)bets).IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            ((IBindingList)bets).Insert(index, value);
        }

        public void Remove(object value)
        {
            ((IBindingList)bets).Remove(value);
            UpdateBinaryFile();
        }

        public void CopyTo(Array array, int index)
        {
            ((IBindingList)bets).CopyTo(array, index);
        }
    }
}
