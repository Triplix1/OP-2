import Funcs

inputfile = "input.txt"
outputfile = "output.txt"

Funcs.OverwriteFile(inputfile,outputfile)

text = Funcs.InputText()

print("\nInput file:")

Funcs.WriteFile(inputfile, text)
Funcs.OutputFile(inputfile)

word = input("Input word: ")

Funcs.GetNewFile(outputfile,inputfile,word)

print("\nInput file:")
Funcs.OutputFile(inputfile)
print("\nOutput file:")
Funcs.OutputFile(outputfile)

Funcs.GetFileInfo(outputfile)