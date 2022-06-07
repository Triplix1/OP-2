from Funcs import AppendFile, GetInput, GetOutput, InputText ,Output

inputpath = "Input.dat"
outputpath = "Output.dat"

append = AppendFile()

text = InputText()

inputfile = GetInput(inputpath, text, append)

print('\nInput file:')

Output(inputpath)

outputfile = GetOutput(inputpath, outputpath)

print('\nOutput file:')

Output(outputpath)

