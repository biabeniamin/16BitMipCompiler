using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16BitMipsCompiler
{
    public class IInstruction
    {
        public ushort InstructionCode => 452;
        private Register _destination;
        private Register _source1;
        private Register _source2;

        public bool HasDestinationRegister => false;

        public bool HasSource1Register => true;

        public bool HasSource2Register => true;

        public Register Source1
        {
            get => _source1;
            set => _source1 = value;
        }
        public Register Source2
        {
            get => _source2;
            set => _source2 = value;
        }
        public Register Destination
        {
            get => _destination;
            set => _destination = value;
        }
        public InstructionType Type { get => InstructionType.I; set => throw new NotImplementedException(); }
    }
}
