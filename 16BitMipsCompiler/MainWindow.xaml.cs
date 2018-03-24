using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            Instructions = new ObservableCollection<Instruction>();
            Instructions.Add(new RInstruction());
            Instructions.Add(new IInstruction());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)

        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            
        }
    }
}
