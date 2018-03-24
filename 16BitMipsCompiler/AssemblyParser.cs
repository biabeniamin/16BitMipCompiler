using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16BitMipsCompiler
{
    public class AssemblyParser
    {
        public static Function GetFunctionFromString(String line)
        {
            if (0 == line.Length)
            {
                return Function.Nop;
            }

            String[] elements = line.Split(' ');
            if (1 > elements.Length)
            {
                return Function.Nop;
            }

            List<Function> possibleFunctions = new List<Function>((Function[])Enum.GetValues(typeof(Function)));

            Function function = possibleFunctions.Find((funct) => funct.ToString().ToLower().Contains(elements[0].ToLower()));

            return function;
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

        public static InstructionType GetInstructionType(Function function)
        {
            int value = (int)function;

            if (0 == (value >> 2))
            {
                return InstructionType.R;
            }

            else if (0 < (value >> 2))
            {
                return InstructionType.I;
            }

            return InstructionType.J;
        }

        public static Instruction Parse(String line)
        {
            Function function = AssemblyParser.GetFunctionFromString(line);
            String[] parameters = GetParametersString(line);
            var type = GetInstructionType(function);

            switch(type)
            {
                case InstructionType.R:
                    Register destination = AssemblyParser.GetRegister(parameters, 1);
                    Register register1 = AssemblyParser.GetRegister(parameters, 1);
                    Register register2 = AssemblyParser.GetRegister(parameters, 2);

                    return new RInstruction(function, destination, register1, register2);
            }
            

            return null;
        }
    }
}
