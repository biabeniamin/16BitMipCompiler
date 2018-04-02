using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _16BitMipsCompiler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Instruction> _instructions;
        private List<AssemblyInstruction> instructions = new List<AssemblyInstruction>();
        private DelegateCommand _delegateLoadCommand;
        private DelegateCommand _delegateSaveCommand;

        public DelegateCommand DelegateSaveCommand
        {
            get { return _delegateSaveCommand; }
            set { _delegateSaveCommand = value; }
        }
        public DelegateCommand DelegateLoadCommand
        {
            get { return _delegateLoadCommand; }
            set { _delegateLoadCommand = value; }
        }

        public ObservableCollection<Instruction> Instructions
        {
            get { return _instructions; }
            set
            {
                _instructions = value;
                OnPropertyChanged("Instructions");
            }
        }

        public ObservableCollection<Register> Registers
        {
            get
            {
                Array values = Enum.GetValues(typeof(Register));
                return new ObservableCollection<Register>(new List<Register>((Register[])values));
            }
        }

        public ObservableCollection<InstructionType> InstructionTypes
        {
            get
            {
                Array values = Enum.GetValues(typeof(InstructionType));
                return new ObservableCollection<InstructionType>(new List<InstructionType>((InstructionType[])values));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            DelegateLoadCommand = new DelegateCommand(LoadFromFile);
            DelegateSaveCommand = new DelegateCommand(SaveInFile);

            Instructions = new ObservableCollection<Instruction>();
            instructions.Add(new AssemblyInstruction("sll", 0, InstructionType.R));
            instructions.Add(new AssemblyInstruction("srl", 1, InstructionType.R));
            instructions.Add(new AssemblyInstruction("add", 2, InstructionType.R));
            instructions.Add(new AssemblyInstruction("sub", 3, InstructionType.R));
            instructions.Add(new AssemblyInstruction("and", 4, InstructionType.R));
            instructions.Add(new AssemblyInstruction("or", 5, InstructionType.R));
            instructions.Add(new AssemblyInstruction("not", 6, InstructionType.R));
            instructions.Add(new AssemblyInstruction("xor", 7, InstructionType.R));

            instructions.Add(new AssemblyInstruction("addi", 0, InstructionType.I));
            instructions.Add(new AssemblyInstruction("lw", 1, InstructionType.I));
            instructions.Add(new AssemblyInstruction("sw", 2, InstructionType.I));
            instructions.Add(new AssemblyInstruction("beq", 3, InstructionType.I));

        }

        private void LoadFromFile()
        {
            using (StreamReader reader = new StreamReader("code.txt"))
            {
                while (!reader.EndOfStream)
                {
                    String line = reader.ReadLine();

                    Instruction i = AssemblyParser.Parse(instructions, line);
                    Instructions.Add(i);

                    int var = i.InstructionCode;
                }


            }

        }

        private void SaveInFile()
        {
            using (StreamWriter writer = new StreamWriter("code.hex"))
            {
                foreach(Instruction instruct in Instructions)
                {
                    writer.Write("\"");
                    writer.Write(instruct.InstuctionCodeSepareted);
                    writer.WriteLine("\"");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)

        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));

        }

    }
}
