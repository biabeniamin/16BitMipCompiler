using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16BitMipsCompiler
{
    public class AssemblyParser
    {
        public static AssemblyInstruction GetAssemblyInstructionFromString(List<AssemblyInstruction> instructions, String line)
        {
            if (0 == line.Length)
            {
                return null;
            }

            String[] elements = line.Split(' ');
            if (1 > elements.Length)
            {
                return null;
            }


            AssemblyInstruction instruction = instructions.Find((ins) => ins.Mnemonic.ToLower().Contains(elements[0].ToLower()));

            return instruction;
        }

        public static String[] GetParametersString(String line)
        {

            for (int i = 0; i < line.Length; i++)
            {
                if (' ' == line[i])
                {
                    line = line.Substring(i + 1);
                    break;
                }
            }

            String[] elements = line.Replace(" ", "").Split(',');

            return elements;
        }

        public static Register GetRegister(String[] parameters, ushort index)
        {
            List<Register> possibleRegisters = new List<Register>((Register[])Enum.GetValues(typeof(Register)));

            Register register = possibleRegisters.Find((funct) => funct.ToString().ToLower().Contains(parameters[index].Replace("$", "").ToLower()));

            return register;
        }

        public static ushort GetValue(String[] parameters, ushort index)
        {
            return Convert.ToUInt16(parameters[index]);
        }

        public static Instruction Parse(List<AssemblyInstruction> instructions, String line)
        {
            AssemblyInstruction instruction = AssemblyParser.GetAssemblyInstructionFromString(instructions, line);
            String[] parameters = GetParametersString(line);

            Register destination, register1, register2;
            ushort immediate;

            switch (instruction.Type)
            {
                case InstructionType.R:
                    destination = AssemblyParser.GetRegister(parameters, 0);
                    register1 = AssemblyParser.GetRegister(parameters, 1);
                    register2 = AssemblyParser.GetRegister(parameters, 2);

                    return new RInstruction(instruction, destination, register1, register2);

                case InstructionType.I:
                    register1 = AssemblyParser.GetRegister(parameters, 0);
                    register2 = AssemblyParser.GetRegister(parameters, 1);
                    immediate = GetValue(parameters, 2);

                    return new IInstruction(instruction, register1, register2, immediate);
            }
            

            return null;
        }
    }
}
